using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    public float baseSpeedDoNotEdit = 2f;
    public float uniqueSpeed = 2f;
    public bool left = true;

    //
    float numberFor;
    //

    public GroundChecker check;

    private Rigidbody2D rbody;
    // Use this for initialization
    void Start()
    {
        //hämtar sin egna Rigidbody2D
        rbody = GetComponent<Rigidbody2D>();
        //jag tar x storleken på objectet och baserar resten av objectets skala på det, jag gör det eftersom det inte är meningen att x och y ska vara olika, spritsen är ju 128*128p
        //jag gör också det för att jag ska kunna ha unika storlekar på mössen medans de samtidigt inte blir pytte små så fort de svänger.
        numberFor = transform.localScale.x;
    }
    private void FixedUpdate()
    {
        if (left == true)
        {
            transform.localScale = new Vector3(numberFor, numberFor, transform.localScale.z);
            //eftersom den åker åt vänster så är hastigheten riktad negativt i x
            rbody.MovePosition(rbody.position + (-(new Vector2(uniqueSpeed, 0) * Time.deltaTime)));
        }
        else
        {
            transform.localScale = new Vector3(-numberFor, numberFor, transform.localScale.z);
            rbody.MovePosition(rbody.position + (new Vector2(uniqueSpeed, 0) * Time.deltaTime));
        }
        if (check.isGrounded == false)
        {
            //om den håller på att åka utför en kant så kommer den att byta värde på boolen som kontrollerar musens riktning mellan väsnter och höger.
            left = !left;
        }
    }
    void Update()
    {
        //casta om en Vector3 till en vektor2
        //"casting"
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerProjectile")
        {
            //den ska ta dmg av dem, inte vända håll också!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        //om den nuddar ett object som inte är mark ska den inte svänga fan
        else if (collision.tag == "Ground"|| collision.tag == "InvisibleWall")
        {
            left = !left;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
