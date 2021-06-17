using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    public CoinsManager cm;

    private void Awake() 
    {
        cm = FindObjectOfType<CoinsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cm.coins += 5;
        }
        Destroy(this.gameObject);
    }
}
