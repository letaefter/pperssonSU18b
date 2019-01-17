using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //static betyder att den variabeln alltid finns i alla scripts och kan nås från överallt och är samma värde för alla object.
    public static int collectedCoinsCombinedValue;
    int value;
    bool yos;
    int spin;
    int aspin;
    int random;
    private void Start()
    {
        //vid start randomiseras lite nummer som bestämmer hur Coin objecten ska rotera inom scenen.
        //och objectets bas värden
        value = 1;
        yos = false;
        spin = Random.Range(1, 5);
        random = Random.Range(1, 3);
        if (spin == 1)
            aspin = 70;
        if (spin == 2)
            aspin = 90;
        if (spin == 3)
            aspin = 120;
        if (spin == 4)
            aspin = 150;
        if (random == 1)
            aspin = -aspin;
    }
    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, aspin * Time.fixedTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om ett gameobject med tag'en "Player" nuddar ett coin så kommer det att sätta en variable: yos, till true
        if (collision.tag == "Player")
        {
            yos = true;
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        //som sedan kollar att om objectet blir Destroy'at så kommer static variabeln som räknar din mängd mynt att incrementas med 1
        if (yos == true)
        {
            collectedCoinsCombinedValue = collectedCoinsCombinedValue + value;
            Debug.Log(collectedCoinsCombinedValue);
        }
        //anledningen till [att yos variabeln finns] är för det blev buggat när jag startade om spelet eftersom man alla coins som man inte hade tagit än då.
        //också för väldigt ofta blev ett coin värt 2 eller 3 gånger värdet innan jag omformulerade koden
    }
}
