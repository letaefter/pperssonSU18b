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
    //om en collider som har satts som en trigger blir "träffad" av en collider så kommer den köra OnTriggerEnter2D
    //om den sedan slutar nuddas så kommer den köra OnTriggerExit2D
    //om en collider som inte är en trigger nuddas av en collider eller rigidbody så kommer den köra OnCollisionEnter2D
    //och när den slutar nuddar så kommer den köra OnCollisionExit2D
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
