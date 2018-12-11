using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        //variabeln "text"'s text kommer uppdateras dynamiskt efter värdet på Coin.collectedCoinsCombinedValue
        //Coin scriptet behöver inte länkas för det har gjorts till en "static" vilket betyder att man kan länka till den i alla script utan att först fetcha den med hjälp av en klass och variabel namn
        //också att det inte är ett script som kan påverkas unikt och vara annorlunda för olika object 
        text.text = string.Format("{0:0000}", Coin.collectedCoinsCombinedValue);
        if (Coin.collectedCoinsCombinedValue < 20)
        {
            //byter färg på texten om man har mer än 20 coins, för att det är kul :)
            text.color = new Color(1, 0, 0);
        }
        else
        {
            text.color = new Color(0, 1, 0);
        }
    }
}
