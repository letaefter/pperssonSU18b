using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileFishScript : MonoBehaviour
{
    public Rigidbody2D rbody;
    public PlayerProjectileFishScript ppfs;
    public WeaponScript kenn;
    void Start()
    {
        //kenn variabeln länkar automatiskt till ett objekt med scriptet WeaponScript.
        //weaponscript finns bara på fisken som man kastar så det är OKEJJ eftersom alla redan existerande fiskar har ju länkat till sig själv tror jag
        kenn = WeaponScript.FindObjectOfType<WeaponScript>();
    }
    void Update()
    {
        //detta scriptet existerar för jag inte är smart nog att veta hur man instaniater ett gameobject med en redan existerande velocity, så istället lägger jag
        //en velocity boost på Update, så när fisken instantiatas så kommer den köra update och då få sin velocity, och sedan tar detta scriptet livet av sig så att den inte får
        //en velocity boost i en annan frame än den första som den existerar i.
        if (kenn.transform.position.x < rbody.position.x)
        {
            //sätter velocity i en vektor som går åt höger och lite uppåt
            rbody.velocity = rbody.velocity + new Vector2(6, 2);
        }
        else
        {
            //sätter velocity i en vektor som är åt vänster och lite uppåt
            rbody.velocity = rbody.velocity - new Vector2(6, -2);
        }
        Destroy(ppfs);
    }
}
