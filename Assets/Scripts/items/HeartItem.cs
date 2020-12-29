using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().life++;
            EventBroker.CallUpdateLifeInUi(collision.GetComponent<PlayerController>().life);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
