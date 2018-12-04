using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHold : MonoBehaviour
{
    public bool edgeHeld = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
