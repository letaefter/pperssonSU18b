using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideMouseSpawn : MonoBehaviour
{
    //detta script används på ett tomt gameObject för att instantiata möss som bara kan gå rakt framåt och som bör instantiatas med fötterna på marken
    //för de har inte rigidbody2d komponenter och de har en funktion som gör att deras rörelse förändras när dom inte längre nuddar mark.
    public GameObject dmouse;
    void Start()
    {
        runsTheSpawn = 0;
        timer = 0;
    }
    float runsTheSpawn;
    float timer;
    float interval;
    void FixedUpdate()
    {
        //jag har detta i FixedUpdate så jag väljer att göra en alternativ sorts timer med hjälp av variabeln timer, som jag incrementar varje frame.
        //sedan med variabeln interval bestämmer jag att jag ska skapa en instance av dmouse (som jag länkar till prefaben SuicideMouse)
        //effektivt så kommer en instanc av SuicideMouse att skapas var 80:e frame eftersom Mathf.CeilToInt(interval) bara kommer
        //att vara == interval 1 gång var 80:e frame vilket motsvarar typ 1.5 sekunders mellanrum
        timer++;
        interval = timer / 80;
        if (interval == Mathf.CeilToInt(interval))
        {
            //prefaben dmouse kommer instantiatas som en clone vid positionen 0, 0, 0
            //den kommer spawna på parenten
            Instantiate(dmouse, gameObject.transform.position, Quaternion.identity);
        }
    }
}
