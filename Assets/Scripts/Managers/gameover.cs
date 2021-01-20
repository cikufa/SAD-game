using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    private GameObject player;
    float timeout=1.5f;
    int blinkCounter = 0;
    //float startTime = 1000;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && !testShield.shieldactive)
        {
            
            //startTime = Time.time; 
            other.GetComponent<PlayerController>().life--;
            other.tag = "notPlayer";
            //other.GetComponent<Collider2D>().enabled = false;
            Invoke("tagBack",timeout);
            EventBroker.CallUpdateLifeInUi(other.GetComponent<PlayerController>().life);
            if (other.GetComponent<PlayerController>().life == 0)
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
