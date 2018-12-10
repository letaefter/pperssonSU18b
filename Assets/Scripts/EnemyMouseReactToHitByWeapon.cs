using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouseReactToHitByWeapon : MonoBehaviour
{
    
    public GameObject hitEnemy;
    public EnemyHitPoints hp;

    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile")
        {
            hp.hp = hp.hp - 1;
        }
    }
}
