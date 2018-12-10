using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMouseScript : MonoBehaviour
{
    public float baseSpeedDoNotEdit = 2f;
    public float uniqueSpeed = 2f;
    //du måste ändra i koden om den ska ändra håll
    public bool left = true;

    //
    float numberFor;
    //
    

    private Rigidbody2D rbody;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        RunAtStart();
    }
    private void RunAtStart()
    {
        numberFor = transform.localScale.x;
    }
    private void FixedUpdate()
    {
        if (left == true)
        {
            transform.localScale = new Vector3(numberFor, transform.localScale.y, transform.localScale.z);
            rbody.MovePosition(rbody.position + (-(new Vector2(uniqueSpeed, 0) * Time.deltaTime)));
        }
        else
        {
            transform.localScale = new Vector3(-numberFor, transform.localScale.y, transform.localScale.z);
            rbody.MovePosition(rbody.position + (new Vector2(uniqueSpeed, 0) * Time.deltaTime));
        }
    }
    void Update()
    {
        //casta om en Vector3 till en vektor2
        //"casting"
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "InvisibleWall")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
