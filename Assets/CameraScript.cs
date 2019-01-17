using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform tf;
    private void Update()
    {
        //Transform tf = spelargameobjectet. 
        // det gör så att positionen av detta scriptets innehavare är densamma som (spelarens) position, minues 10 i Z axeln.
        //anledning är för det blev ett bug med att kameran inte visade något om man tog powerup'en
        transform.position = tf.position - new Vector3(0, 0, 10);
    }
}
