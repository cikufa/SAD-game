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

        ufosound.PlayDelayed(4); //17.5 to 29
        ufocolorsound.PlayDelayed(15); //29 to 38

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
