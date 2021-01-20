using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerController>().life >= 3)
            {
                return;
            }
            collision.GetComponent<PlayerController>().life++;
            EventBroker.CallUpdateLifeInUi(collision.GetComponent<PlayerController>().life);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
