using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTrigger : MonoBehaviour
{
    //public Rigidbody player;
    public GameObject selectLevelPanel;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
            selectLevelPanel.SetActive(true);

    }

    void OnTriggerExit(Collider other) 
    {
         if(other.tag == "Player")
            selectLevelPanel.SetActive(false);
    }
}
