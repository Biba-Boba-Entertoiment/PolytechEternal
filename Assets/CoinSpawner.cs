using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    
    public void SpawnCoin()
    {
        int randomValue = Random.Range(0, 4);
        Debug.Log(randomValue);
        if (randomValue > 1)
        {
  
            Instantiate(Coin, transform.position, Quaternion.identity);
            Debug.Log(randomValue);
        }
    }
}
