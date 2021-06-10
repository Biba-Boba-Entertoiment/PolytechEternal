using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float stepDelay;
    public bool isPlayer;
    private AudioSource audioSource;
    //public AudioClip step;
    private Rigidbody rb;
    
    public AudioClip stepClip;
    public AudioClip jumpClip;
    public AudioClip hitClip;
    public AudioClip projectileClip;
    public AudioClip deathClip;
    public AudioClip winClip;
    private float timer = 0;
    void Start()
    {
        //audioClipAudioClip = GetComponent<AudioClip>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
                    audioSource.PlayOneShot(stepClip);
                    
                }
            if(Input.GetKeyDown(KeyCode.Space)) 
                audioSource.PlayOneShot(jumpClip);
            timer = 0.01f;
        }
        else if (rb.velocity != Vector3.zero)
        {
            audioSource.PlayOneShot(stepClip);
            timer = 0.01f;
        }
    }

    }
     
    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitClip);
    }
    
    public void PlayProjectileSound()
    {
        audioSource.PlayOneShot(projectileClip);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winClip);
    }
}
