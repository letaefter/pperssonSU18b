using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public PlayerMovement aad;
    public GameObject rdoby;
    // Use this for initialization
    void Start()
    {
        yes = 0;
    }
    float yes;
    // Update is called once per frame
    void Update()
    {
        if (yes == 1)
        {
            rdoby.transform.localScale = rdoby.transform.localScale * 1.3f;
            aad.jumpSpeed = aad.jumpSpeed * 1.5f;
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
