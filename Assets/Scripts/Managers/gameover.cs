using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    private GameObject player;
    float timeout=1.5f;
    //float startTime = 1000;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");

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
