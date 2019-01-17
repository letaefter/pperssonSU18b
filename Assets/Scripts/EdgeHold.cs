using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHold : MonoBehaviour
{
    //en mindre version av groundcheck som gör att om man landar precis på en kant så kan man hoppa upp. typ som om man hänger och drar sig upp
    public bool edgeHeld = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            edgeHeld = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            edgeHeld = false;
        }
    }
}
