using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCompleted : MonoBehaviour
{
    public string number;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoadLevel("levelcompletion"+number);
        }
    }
}
