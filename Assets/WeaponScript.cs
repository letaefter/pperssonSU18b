using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject fish;
    public Rigidbody2D rfish;
    void Start()
    {
        bs = false;
        timer = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && bs == false)
        {
            Instantiate(fish, gameObject.transform.position + new Vector3(0.3f, 0, 0), Quaternion.identity);
            bs = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && bs == false)
        {
            Instantiate(fish, gameObject.transform.position - new Vector3(0.3f, 0, 0), Quaternion.identity);
            bs = true;

        }
        if (bs == true)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 1)
            {
                bs = false;
                timer = 0;
            }
        }

    }
    public bool bs;
    public float timer;
   
}
