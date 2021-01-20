using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story : MonoBehaviour
{
    public AudioSource ufosound;
    public AudioSource ufocolorsound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ufo1", 4);

        //ufosound.PlayDelayed(4); //17.5 to 29
        //ufocolorsound.PlayDelayed(15);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ufo1()
    {

        ufosound.Play();
        Invoke("ufo2", 11);

    }
    void ufo2()
    {

        ufocolorsound.Play();
        
    }
}
