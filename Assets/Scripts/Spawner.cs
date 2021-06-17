using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Enemy;
    public int maxCount = 0;
    public int currentCount;
    public float timer;
    public float cd;
    // private Collider enemyCollider;
    // private HealthScript healthScript;
    // private Rigidbody rigidBody;

    //float cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;

    void Start()
    {
        currentCount = 0;
        timer = 0;
        //SpawnPos.position.Set(SpawnPos.position.x + 10, SpawnPos.position.y, SpawnPos.position.z);
        // enemyCollider = Enemy.GetComponent<Collider>();
        // healthScript = Enemy.GetComponent<HealthScript>();
        // rigidBody = Enemy.GetComponent<Rigidbody>();
        // enemyCollider.enabled = true;
        // healthScript.enabled = true;
        // rigidBody.useGravity = true;
        // StartCoroutine(SpawnCD());
        // enemyCollider.enabled = true;
        // healthScript.enabled = true;
        // rigidBody.useGravity = true;
    }
    void Update() 
    {
        if(currentCount < maxCount)
        {
            Spawn();
        }
    }    

    void Spawn()
    {
        if((timer += Time.deltaTime) > cd)
            {
                timer = 0.01f;
                Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
                currentCount++;
            }
    }



    // void Repeat()
    // {
    //     count++; 
    //     enemyCollider.enabled = true;
    //     healthScript.enabled = true;
    //     rigidBody.useGravity = true;
    //     StartCoroutine(SpawnCD());
    //     enemyCollider.enabled = true;
    //     healthScript.enabled = true;
    //     rigidBody.useGravity = true;
    // }


    // IEnumerator SpawnCD()
    // {
    //     //SpawnPos.position.Set(SpawnPos.position.x + 10, SpawnPos.position.y, SpawnPos.position.z);

    //     yield return new WaitForSeconds(1f);
    //     enemyCollider.enabled = true;
    //     healthScript.enabled = true;
    //     rigidBody.useGravity = true;
    //     Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
    //     //Enemy.SetActive(true);
    //     enemyCollider.enabled = true;
    //     healthScript.enabled = true;
    //     rigidBody.useGravity = true;
    //     if (count < 2)
    //     {
    //         enemyCollider.enabled = true;
    //         healthScript.enabled = true;
    //         rigidBody.useGravity = true;
    //         Repeat();
    //         enemyCollider.enabled = true;
    //         healthScript.enabled = true;
    //         rigidBody.useGravity = true;
    //     }
    // }
}
