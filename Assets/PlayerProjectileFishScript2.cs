using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileFishScript2 : MonoBehaviour
{
    //detta script gör så att fisken kommer förstöras 1.75 sekunder efter den spawnar.
    void Update()
    {
        //betyder att den kommer ta bort objectet "gameObject" 1.75 sekunder efter den kallas. gameObject är objektet som detta script sitter på, det sitter på fisken.
        Destroy(gameObject, 1.75f);
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
