using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSFX : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        EventBroker.GameOver += PlayerRespawned;
        source = GetComponent<AudioSource>();   
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            source.Play();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && source.isPlaying)
        {
            source.Stop();
        }
    }

    void PlayerRespawned()
    {
        source.Stop();
    }
}
