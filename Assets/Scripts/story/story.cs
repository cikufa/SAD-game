using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story : MonoBehaviour
{
    public GameObject ufosound;
    public GameObject ufocolorsound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {



        //ufosound.PlayDelayed(4); //17.5 to 29
        //ufocolorsound.PlayDelayed(15); //29 to 38

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 4)
        {
            ufosound.SetActive(true);

        }
        if (Time.time > 15)
        {
            ufosound.SetActive(false);
            ufocolorsound.SetActive(true);

        }

    }

}