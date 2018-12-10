using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewTextScript : MonoBehaviour
{
    public GameObject spawn;
    public GameObject destroy;
    public PlayerCheck pchekc;
    public PlayerCheck pseconndkc;
    void Start()
    {
        spawn.SetActive(false);
    }
    void Update()
    {
        if (pchekc.playerTriggeredIt == true)
        {
            spawn.SetActive(true);
        }
    }
}
