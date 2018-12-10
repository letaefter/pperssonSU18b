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
        text.text = string.Format("{0:0000}", Coin.collectedCoinsCombinedValue);
        if (Coin.collectedCoinsCombinedValue < 20)
        {
            text.color = new Color(1, 0, 0);
        }
        else
        {
            text.color = new Color(0, 1, 0);
        }
    }
}
