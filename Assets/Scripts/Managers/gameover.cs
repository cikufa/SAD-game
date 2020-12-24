using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    private GameObject player; 
    float startTime = 1000;
    void Update()
    {
        Debug.Log("in update:");
        //Debug.Log(Time.deltaTime);

        if (Time.time > startTime + 5)
        {
            startTime = Time.time;
            Debug.Log("timeout");
           // this.GetComponent<Collider2D>().isTrigger = false;
           // this.GetComponent<Collider2D>().isTrigger = true;
            player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerController>().life--;
            EventBroker.CallUpdateLifeInUi(player.GetComponent<PlayerController>().life);
            if (player.GetComponent<PlayerController>().life == 0)
            {
                //Destroy(other.gameObject);
                player.gameObject.SetActive(false);
                EventBroker.CallGameOver();
                //GameManager.Instance.TogglePause();                
            }

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Invoke("OnTriggerExit2D", 1);
        if (other.gameObject.tag == "Player" && !testShield.shieldactive)
        {
            Debug.Log("enter");
            startTime = Time.time; 
            other.GetComponent<PlayerController>().life--;
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
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !testShield.shieldactive)
        {
            Debug.Log("exit");
            startTime = 1000;
        }
    }
     
}
