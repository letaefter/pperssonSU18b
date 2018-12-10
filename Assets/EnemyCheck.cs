using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public GameObject eScene;
    public int dn;
    void Start()
    {
        eScene.SetActive(false);
    }
    void Update()
    {
        if (dn <= 0)
        {
            eScene.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            dn++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            dn--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
    }

}
