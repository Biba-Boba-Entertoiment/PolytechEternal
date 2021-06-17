using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsAmountText;

    private void Update() 
    {
        coinsAmountText.text = coins.ToString();    
    }


    public void SpendCoins(int amount)
    {
        coins -= amount;
    }

}
