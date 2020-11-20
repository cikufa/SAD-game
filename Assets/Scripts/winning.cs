using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{

    public GameObject canvasObject;

    void Start()
    {
        Debug.Log("Start");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Object entered");
            canvasObject.SetActive(true);
        }

    }
}
