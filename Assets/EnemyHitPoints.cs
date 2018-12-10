using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoints : MonoBehaviour
{
    public GameObject enemy;
    public int hp;
    void Start()
    {
    }
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(enemy);
        }
    }
}
