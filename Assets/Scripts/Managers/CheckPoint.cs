using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("notPlayer"))
        {
            GetComponentInParent<CheckPointManager>().CheckPointIsTriggered(transform.GetSiblingIndex(), this);
            transform.GetChild(0).GetComponent<Animator>().enabled = false;
            Debug.Log("CheckPointTriggered");
        }
    }
}
