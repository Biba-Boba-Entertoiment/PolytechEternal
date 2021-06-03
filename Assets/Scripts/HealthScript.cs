using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 10;
    [HideInInspector] public int currentHealth;
    private AudioManager audioManager;
    private Animator anim;
    private EnemyMove enemyMove;
    private int coins;
    CoinsManager coinsManager;
    public GameObject Coin;
    
    [HideInInspector] public bool characterDied;
    public bool isPlayer;
    public bool isPlayerDead;
    void Awake() 
    {
        anim = GetComponent<Animator>();
        enemyMove = GetComponent<EnemyMove>();
        audioManager = GetComponent<AudioManager>();
        
    }
    void Start() 
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int attackDamage)
    {
        if(isPlayerDead)
            return;
        
        currentHealth -= attackDamage; // отнимаем от текущего хп входящий урон
        Debug.Log("HP = " + currentHealth);
        anim.SetTrigger("Hurt"); // триггерим анимацию получения урона

        if(currentHealth <= 0) // если хп меньше или равно нулю
        {
            //characterDied = true;
            //anim.SetBool("IsDead", true);
            //Die(); // смэрть
  
            if (isPlayer)
            {
                //Debug.Log("Player Died!");
                isPlayerDead = true;
                PlayerDie();
            }
            else
            {
                //Debug.Log("Enemy Died!");
                GameController.score += 10; // прибавляем игроку по 10 очков за каждого убитого
                EnemyDie();
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(isPlayer)
            if(other.tag == "Hole")
            {              
                anim.SetTrigger("Fall");
                StartCoroutine(Coroutine());
            }
    }
    
    void PlayerDie()
    {
        audioManager.PlayDeathSound();
        GetComponent<PlayerController>().enabled = false;
        Camera.main.GetComponent<CameraFollow2>().enabled = false;
        this.enabled = false; // выключаем его
        Destroy (this.gameObject, 3); 
    }
    void EnemyDie()
    {      
        audioManager.PlayDeathSound();
        GetComponent<Rigidbody>().useGravity = false; 
        GetComponent<EnemyMove>().enabled = false;
        GetComponent<Collider>().enabled = false;  
        Destroy (this.gameObject, 5);
        
        //int randomValue = Random.Range(0, 3);
        if (true)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
        }

    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.0f);
        currentHealth = 0;
        isPlayerDead = true;
        PlayerDie();         
    }

    public void GetHealthPoints()
    {
        if(currentHealth < maxHealth)
            currentHealth += 2;
    }
}
