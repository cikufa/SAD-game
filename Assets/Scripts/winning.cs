using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{

    public GameObject canvasObject;
    public GameObject gameStatus;

    void Start()
    {
        Debug.Log("Start");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && gameStatus.tag != "lost")
        {
            Debug.Log("level done");
            canvasObject.SetActive(true);
        }

    }
}
