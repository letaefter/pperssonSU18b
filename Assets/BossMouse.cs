using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouse : MonoBehaviour
{
    public GameObject tekst;
    public EnemyMouseReactToHitByWeapon bmus;
    void Start()
    {
        tekst.SetActive(false);
        timer = 0;
        go = false;
    }
    public bool go;
    public float timer;
    void Update()
    {
        if (go == true)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 3)
            {
                tekst.SetActive(false);
                go = false;
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile" && Coin.collectedCoinsCombinedValue < 20)
        {
            bmus.hp.hp = 6;
            tekst.SetActive(true);
            go = true;
        }
        else if (collision.tag == "PlayerProjectile" && Coin.collectedCoinsCombinedValue >= 20)
        {

        }
    }
}
