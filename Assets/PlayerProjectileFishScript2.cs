using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileFishScript2 : MonoBehaviour
{
    //detta script gör så att fisken kommer förstöras 2 sekunder efter den spawnar.
    //och så den försvinner om den träffar en trigger som har tag'en "Enemy"
    private void Start()
    {
        //betyder att den kommer ta bort objectet "gameObject" 2 sekunder efter den kallas. gameObject är objektet som detta script sitter på, det sitter på fisken.
        Destroy(gameObject, 2f);
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om den träffar en fiende först så kommer den att förstöras snabbare.
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    public EnemyHitPoints hp;
}
