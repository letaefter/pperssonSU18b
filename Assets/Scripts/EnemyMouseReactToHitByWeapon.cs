using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouseReactToHitByWeapon : MonoBehaviour
{

    public GameObject hitEnemy;
    public EnemyHitPoints hp;
    public bool go;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile")
        {
            go = true;
        }
    }
    private void Update()
    {
        if (go == true)
        {
            //hp = EnemyHitPoints scriptet där fienden tar skada om den blir träffad av en fisk. hp.hp betyder variabeln "hp" inuti EnemyHitPoints scriptet som finns i detta script som också "hp"
            hp.hp = hp.hp - 1;
            go = false;
        }
    }
}
