using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsAmountText;
    public int wepfwnef;

    private void Update() 
    {
        coinsAmountText.text = coins.ToString();
    }

    public void RandomChance()
    {
        int randomValue = Random.Range(0, 3);
        if(randomValue > 2)
            coins += 5;
    }

    public void SpendCoins(int amount)
    {
        coins -= amount;
    }
}
