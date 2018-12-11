using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawn;
    public bool den;
    void Start()
    {
        transform.position = spawn.position;
    }
    void Update()
    {
        if (transform.position.x >= 22 && transform.position.y >= -3.5f)
        {
            den = false;
            spawn.position = new Vector2(22, -4);
            Debug.Log("kanser");
        }
    }
    
}
