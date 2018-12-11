using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject fish;
    public bool bs;
    public float timer;
    void Start()
    {
        bs = false;
        timer = 0;
    }
    void Update()
    {
        //man använder K och L för att skjuta en fisk åt vänster respektive höger.
        if (Input.GetKeyDown(KeyCode.L) && bs == false)
        {
            //en lösning på mitt problem med en instantiatad sak som har en velocity i början är att jag istället spawnar fisken till höger, eller till vänst om gubben
            //om jag vill skjuta min fisk till höger, så kommer fisken att spawna positivt på x axeln (relativt till spelarens position.
            //sedan i mitt script (PlayerProjectileFishScript.cs 21) som specifikt projectilen som skjuts så baseras dess velocity's riktning 
            //på dess relativa x position till spelaren (om den är positiv eller negativ)
            Instantiate(fish, gameObject.transform.position + new Vector3(0.3f, 0, 0), Quaternion.identity);
            //bs boolen startar en cooldown timer som blockar möjligheten att instantiata fler fiskar tills intervallen är färdig.
            bs = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && bs == false)
        {
            //fisken instantiatas negativt på x axeln relativt till (gameObject) som i detta fall är spelaren, eftersom detta scriptet finns på spelaren.
            Instantiate(fish, gameObject.transform.position - new Vector3(0.3f, 0, 0), Quaternion.identity);
            bs = true;
        }
        if (bs == true)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 0.75f)
            {
                bs = false;
                timer = 0;
            }
        }
    }
}
