using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameover : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject gameStatus;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !testShield.shieldactive)
        {
            other.transform.GetComponent<PlayerController>().life--;
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
}
