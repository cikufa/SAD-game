using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brake : MonoBehaviour, IPointerDownHandler
{
    PlayerController player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        player.Brake();
    }
}
