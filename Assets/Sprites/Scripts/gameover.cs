using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gameover : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !testShield.shieldactive)
        {           
            other.GetComponent<PlayerController>().life--;
            EventBroker.CallUpdateLifeInUi(other.GetComponent<PlayerController>().life);
            if (other.GetComponent<PlayerController>().life == 0)
            {
                EventBroker.CallGameOver();
                //GameManager.Instance.TogglePause();                
            }            
        }

    }
}
