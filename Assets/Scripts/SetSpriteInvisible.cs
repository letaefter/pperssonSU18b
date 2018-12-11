using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteInvisible : MonoBehaviour
{
    void Start()
    {
        //hämtar SpriteRenderer komponenten i objectet, går sedan in i dess aktiverade status i inspectorn och säger att den ska stängas av
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
