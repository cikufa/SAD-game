using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gameover : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject gameStatus;
    // public GameObject Player;

    void Start()
    {


        //gameStatus.tag = "Untagged";
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && gameStatus.tag != "won" && !testShield.shieldactive)
        {
            other.GetComponent<PlayerController>().life--;
            if (other.GetComponent<PlayerController>().life == 0)
            {
                other.GetComponent<PlayerController>().hasLost = true;
                canvasObject.SetActive(true);
                gameStatus.tag = "lost";
            }            
        }

    }



}
