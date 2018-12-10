using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public bool playerTriggeredIt;
    void Start()
    {
        playerTriggeredIt = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerTriggeredIt = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    private void Update()
    {
    }
}
