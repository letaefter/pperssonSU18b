using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextScript2 : MonoBehaviour
{
    public GameObject self;
    public GameObject tText;
    public PlayerCheck trigger;
    public PlayerCheck bTrigger;
    public PlayerMovement pmove;
    public bool once;
    void Start()
    {
        pmove = PlayerMovement.FindObjectOfType<PlayerMovement>();
        once = false;
    }

    void Update()
    {
        //jag har 2 st empty gameObjects i prefaben som detta script sitter i, och med dem två så kan jag måla upp en "låda" genom att placera vänstra bottenhörnet, och högra topphörnet
        //därför om karaktären är inuti lådan som skapas så aktiveras tTExten som är unik för varje prefab, och en bool: once, som är till för att kunna selfdestructa detta object, för att
        //göra så att man bara kan trigga texten en gång. Det händer om tag'en på en unik prefab har satts som "KeepOff"
        if (pmove.transform.position.x < trigger.transform.position.x && pmove.transform.position.y < trigger.transform.position.y
            && pmove.transform.position.x > bTrigger.transform.position.x && pmove.transform.position.y > bTrigger.transform.position.y)
        {
            //SetActive klickar på och av "boolen" som är brevid varje objekts namn i inspectorn för att sätta på eller av objectet.
            tText.SetActive(true);
            //once är en bool som gör att objectet kan selfdestructa efter texten har visats en gång, ifall tag'en är "KeepOff"
            once = true;
        }
        else
        {
            //om man står utanför rutan som skapas utav de två tomme gameObjects som finns i prefaben så är texten avstängd
            tText.SetActive(false);
        }
        //detta gör så att texten bara kan bli sedd en gång om tag'en på parenten i prefab'en är "KeepOff", eftersom då Destroy'ar den sig själv efter man har sett texten en gång.
        if (tText.activeSelf == false && once == true && self.tag == "KeepOff")
        {
            Destroy(self);
        }
    }

}
