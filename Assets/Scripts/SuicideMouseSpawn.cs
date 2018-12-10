using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideMouseSpawn : MonoBehaviour
{
    public GameObject dmouse;
    // Use this for initialization
    void Start()
    {
        runsTheSpawn = 0;
        timer = 0;
    }
    float runsTheSpawn;
    float timer;
    float interval;
    // Update is called once per frame
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
            Instantiate(dmouse, gameObject.transform.position, Quaternion.identity);
        }
    }
}
