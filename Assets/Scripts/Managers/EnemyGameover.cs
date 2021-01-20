using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameover : MonoBehaviour
{
    private GameObject player;
    float timeout=1.5f;
    int blinkCounter = 0;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    private void Update()
    {
        if (player.tag == "notPlayer")
        {
            blinkCounter++;
            if (blinkCounter >= 10)
            {
                player.GetComponent<Renderer>().enabled = false;
            }
            if (blinkCounter >= 20)
            {
                player.GetComponent<Renderer>().enabled = true;
                blinkCounter = 0;
            }
        }
        else
        {
            player.GetComponent<Renderer>().enabled = true;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !testShield.shieldactive)
        {
            other.transform.GetComponent<PlayerController>().life--;
            //player.GetComponent<Collider2D>().enabled = false;
            player.tag = "notPlayer";
            Invoke("tagBack", timeout);
            EventBroker.CallUpdateLifeInUi(other.transform.GetComponent<PlayerController>().life);
            if (other.transform.GetComponent<PlayerController>().life == 0)
            {
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                EventBroker.CallGameOver();
                //GameManager.Instance.TogglePause();
            }
        }

    }
    void tagBack()
    {
        //player.GetComponent<Collider2D>().enabled = true;
        player.tag = "Player";
    }
}
