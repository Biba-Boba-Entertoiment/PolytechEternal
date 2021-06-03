using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            startAnim.SetBool("startOpen", true);
        //Debug.Log("startOpen");
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            startAnim.SetBool("startOpen", false);
            dm.EndDialogue();
        }
    }
}
