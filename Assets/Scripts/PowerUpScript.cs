using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public PlayerMovement aad;
    public GameObject rdoby;
    float yes;
    void Start()
    {
        yes = 0;
    }
    void Update()
    {
        if (yes == 1)
        {
            //kommer gå in i spelarens huvudscript för att tillfälligt (PlayerMovement restricterar PowerUps tidsgräns) ge spelaren ett högre hopp, och en större sprite.
            rdoby.transform.localScale = rdoby.transform.localScale * 1.3f;
            aad.jumpSpeed = aad.jumpSpeed * 1.5f;
            //sedan deaktiveras powerup objectet så man inte kan aktivera den igen
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yes = 1;
        }
    }
}
