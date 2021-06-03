using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public Transform projectilePoint;
    public GameObject projectile;
    public Transform hitPosition;
    public LayerMask otherLayer;

    public float Reboot;
    public bool accesAttack;
    private float time;
    public int numbersOfCigarette = 3;
    public TMP_Text numbersOfCigaretteText;
    //public Text numbersOfCigaretteText;
    private AudioManager audioManager;
    private HealthScript healthScript;
    public float attackRange;   
    public int attackDamage = 1;
    private string temp;
    private Animator anim;

    void Start() 
    {
        anim = GetComponent<Animator>();
        healthScript = GetComponent<HealthScript>();
        temp = numbersOfCigarette.ToString();
        audioManager = GetComponent<AudioManager>();
        
    }

    void Update()
    {          
        if (healthScript.isPlayer == true)
        {
            if ((time += Time.deltaTime) > 1.0f)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    time = 0.01f;
                    if (numbersOfCigarette != 0)
                    {
                        Shoot();
                        numbersOfCigarette--;
                        
                    }
                }
            }
            numbersOfCigaretteText.text = numbersOfCigarette.ToString();

            if (Input.GetKeyDown(KeyCode.Z))
            {
            if(( time += Time.deltaTime) > 1.0f)
            {
                time = 0.01f;
                Hit();
            }
                
            }
        }

    }

    public void AttackReset()
    {
        accesAttack = true;
        //Debug.Log("accesAttack = true");
    }

    public void Shoot()
    {
        if (accesAttack == true)
        {
            audioManager.PlayProjectileSound();
            Instantiate(projectile, projectilePoint.position, projectilePoint.rotation);
            anim.SetTrigger("Shoot");

        }
        
    }

    public void GetCigarettes()
    {
        if(numbersOfCigarette < 20)
            numbersOfCigarette += 3;
    }

    public void Hit()
    {   
        //float timer = 0f;
        
        anim.SetTrigger("Attack");
        audioManager.PlayHitSound();
        // массив всех коллайдеров объектов, 
        // которые попали в радиус атаки,
        // у которых соответствубщий otherLayers слой  
        Collider[] hit = Physics.OverlapSphere(hitPosition.position, attackRange, otherLayer);

        foreach (Collider other in hit) // пиздим их всех
        {
            // берем скрипт объекта, в который попали, 
            // и обращаемся к его методу получения урона
            other.GetComponent<HealthScript>().TakeDamage(attackDamage);
        }
        
        //hitCollider.enabled = false;

    } 

}
