using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTileMapScript : MonoBehaviour
{
    public GameObject instaTile;
    public GameObject sSpike;
    float timerr;
    float timer;
    void Start()
    {
        timerr = 0;
        timer = 0;
        sSpike.SetActive(false);
    }
    void Update()
    {
        if (timerr == 1f)
        {
            timer = timer + Time.deltaTime;
        }
        if (timer >= 5f)
        {
            instaTile.SetActive(true);
        }
        if (timer >= 6f)
        {
            timer = 0f;
            timerr = 0f;
        }
        if (timer >= 4f)
        {
            sSpike.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timerr = 1;
        instaTile.SetActive(false);
    }
}
