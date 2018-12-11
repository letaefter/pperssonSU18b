using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoints : MonoBehaviour
{
    //om hp på objectet som detta script sitter på bliva mindre än 1 (int) så kommer gameObjectet inte existera längre :)
    public int hp;
    void Update()
    {
        // designad för att man ska lägga en unik hp på varje enemy (kan prefaba en med fast hp annars (kan också göra ett hp script för varje unik fiendetyp fast orkar inte))
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
