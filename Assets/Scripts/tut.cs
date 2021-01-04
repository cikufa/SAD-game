using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class tut : MonoBehaviour
{
    //public int tutNum;
    public GameObject bglight;
    public GameObject input;

    public GameObject enemytut;
    public GameObject tutLight;
    public GameObject nearlamp1;
    public GameObject nearlamp2;
    public GameObject nearenemy1;
    public GameObject nearenemy2;
    public GameObject nearenemy3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("notPlayer"))
        {
            bglight.GetComponent<Light2D>().intensity = 0.17f;
            input.SetActive(false);
            nearlamp1.GetComponent<Light2D>().intensity = 0.4f;
            nearlamp2.GetComponent<Light2D>().intensity = 0.4f;
            nearenemy1.SetActive(false);
            nearenemy2.SetActive(false);
            nearenemy3.SetActive(false);

            enemytut.SetActive(true);
            tutLight.SetActive(true);
            Invoke("backToNormal", 4);

        }
    }
    void backToNormal()
    {
        input.SetActive(true);
        bglight.GetComponent<Light2D>().intensity = 0.3f;
        nearlamp1.GetComponent<Light2D>().intensity = 1;
        nearlamp2.GetComponent<Light2D>().intensity = 1;
        nearenemy1.SetActive(true);
        nearenemy2.SetActive(true);
        nearenemy3.SetActive(true);
        Destroy(this); //destroy collider
        Destroy(tutLight);
    }


}
