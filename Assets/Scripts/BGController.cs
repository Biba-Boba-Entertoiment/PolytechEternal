using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    public float speed = 0f;
    float pos = 0f;
    private RawImage image;
    //public Rigidbody cam;
    private Vector3 prevPos, curPos;
    
    void Start()
    {
        prevPos = Camera.main.transform.position;
        image = GetComponent<RawImage>();
        //playerBody = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Camera.main.transform.position != prevPos)
        {
        pos += speed * Time.deltaTime;
        if(pos > 1f)
            pos -= 1f;
        image.uvRect = new Rect(pos, 0, 2.5f, 1);
        prevPos = Camera.main.transform.position;
        }
    }
  
}
