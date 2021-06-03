using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float stepDelay;
    //public AudioClip step;
    private Rigidbody rb;
    public AudioSource stepSource;
    public bool isPlayer;
    public AudioSource jumpSource;
    public AudioSource hitSource;
    public AudioSource projectileSorce;
    public AudioSource deathSource;
    public AudioSource winSource;
    private float timer = 0;
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(timer == 0 || (timer += Time.deltaTime) > stepDelay)
    {
        if(isPlayer)
        {
            if(!Input.GetKey(KeyCode.Space))
                if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.S))
                {
                    stepSource.PlayOneShot(stepSource.clip);
                    
                }
            if(Input.GetKeyDown(KeyCode.Space)) 
                jumpSource.PlayOneShot(jumpSource.clip);
            timer = 0.01f;
        }
        else if (rb.velocity != Vector3.zero)
        {
            stepSource.PlayOneShot(stepSource.clip);
            timer = 0.01f;
        }
    }

    }
     
    public void PlayHitSound()
    {
         hitSource.PlayOneShot(hitSource.clip);
    }
    
    public void PlayProjectileSound()
    {
        projectileSorce.PlayOneShot(projectileSorce.clip);
    }

    public void PlayDeathSound()
    {
        deathSource.PlayOneShot(deathSource.clip);
    }

    public void PlayWinSound()
    {
        winSource.PlayOneShot(winSource.clip);
    }
}
