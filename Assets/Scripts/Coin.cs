using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int collectedCoinsCombinedValue;
    int value;
    int yos;
    int spin;
    int aspin;
    private void Start()
    {
        value = 1;
        yos = 0;
        spin = Random.Range(1,5);
        if (spin == 1)
            aspin = 70;
        if (spin == 2)
            aspin = 90;
        if (spin == 3)
            aspin = 120;
        if (spin == 4)
            aspin = 150;
        if (spin == 5)
            aspin = 20000;
    }
    private void FixedUpdate()
    {
        transform.Rotate(0f, aspin * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yos = 1;
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (yos == 1)
        {
            collectedCoinsCombinedValue = collectedCoinsCombinedValue + value;
            Debug.Log(collectedCoinsCombinedValue);
        }
    }
}
