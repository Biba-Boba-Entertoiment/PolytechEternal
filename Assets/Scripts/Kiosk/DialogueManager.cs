using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public GameObject player;
    public Text dialogueText;
    public Text nameText;

    public Animator boxAnim;
    public Animator startAnim;
    public CoinsManager coinsManager;
    public PlayerAttack playerAttack;
    public HealthScript healthScript;
    private Queue<string> sentences;
    int coins;
    
    private void Start()
    {
        //coins = coinsManager.coins;
        sentences = new Queue<string>();
        // playerAttack = GetComponent<PlayerAttack>();
        //healthScript = GetComponent<HealthScript>();
       
    }

    private void Update()
    {
        
        // playerAttack = GetComponent<PlayerAttack>();
        

    }
    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentance in dialogue.sentences)
        {
            sentences.Enqueue(sentance);
        }

        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentance = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentance));

    }

    IEnumerator TypeSentence(string sentance)
    {
        dialogueText.text = "";
        foreach(char letter in sentance.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            dialogueText.text += letter;
            yield return null;

        }
    }

    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
    public void BuyOneCigarette()
    {
        if(coinsManager.coins >= 2)
        {
            Debug.Log("сигаретка далась");       
            playerAttack.GetOneCigarette();
            coinsManager.SpendCoins(2);
        }
    }
    public void BuyCigarettePack()
    {
        if(coinsManager.coins >= 30)
        {
            Debug.Log("сигареті дались");       
            playerAttack.GetCigarettePack();
            coinsManager.SpendCoins(30);
        }
    }
        
    public void BuyEnergyDrink()
    {
        if(coinsManager.coins >= 15)
        {
            Debug.Log("мммм хпшечка");
            healthScript.GetHealthPoints();
            coinsManager.SpendCoins(15);
        }
        
    }
}

