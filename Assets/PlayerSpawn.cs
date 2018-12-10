using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector2 vec2;
    void Start()
    {
        transform.position = vec2;
    }
    void Update()
    {
        
    }
}
