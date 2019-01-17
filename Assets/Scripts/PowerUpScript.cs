using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public PlayerMovement aad;
    public GameObject rdoby;
    bool yes;
    void Start()
    {
        yes = false;
    }
    void Update()
    {
        //yes blir true om man nuddar PowerUp Objectet och sedan leder det till att en domino variabel i PLayerMovement orsakar att powerupen fungerar.
        if (yes == true)
        {
            //kommer gå in i spelarens PlayerMovement.cs för att tillfälligt (PlayerMovement restricterar PowerUps tidsgräns) ge spelaren ett högre hopp, och en större sprite.
            //I det scriptet kommer sedan powerupen avslutas efter en tidsgräns
            aad.empowered = 1;
            //sedan deaktiveras powerup objectet så man inte kan aktivera den igen
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yes = true;
        }
    }
}
