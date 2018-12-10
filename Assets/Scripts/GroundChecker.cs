using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    public BoxCollider2D poly;
    private void Start()
    {
        poly = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
        isGrounded = false;
        }
    }
}
