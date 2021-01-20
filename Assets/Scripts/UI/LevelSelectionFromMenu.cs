using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionFromMenu : MonoBehaviour
{
     /*public AudioClip sound;
    
     private AudioSource source { get { return GetComponent<AudioSource>(); } }
     */
   
    public Transform levelSelection;

    public void ToLevelSelection()
    {
        //gameObject.AddComponent<AudioSource>();
        //source.clip = sound;
        //source.PlayOneShot(sound);

        levelSelection.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
    /*
    public void Play()
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
    }*/
}
