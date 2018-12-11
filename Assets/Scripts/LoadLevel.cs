using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string sceneToLoad = "SampleScene";
    public PlayerSpawn pspawn;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        Coin.collectedCoinsCombinedValue = 0;
    //        SceneManager.LoadScene(sceneToLoad);
    //        yos = false;
    //        yos1 = false;
    //        yos2 = false;
    //    }
    //}
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Coin.collectedCoinsCombinedValue = 0;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
