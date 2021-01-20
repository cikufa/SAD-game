using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class tutorial : MonoBehaviour
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
    private GameObject player;
     public GameObject startToDrag;
     public GameObject arrow;
    public GameObject avoid;

    // Start is called before the first frame update
    void Start()
    {
        startToDrag.SetActive(true);
        player = GameObject.FindWithTag("Player");
        /*if(player= null)
        {
            player = GameObject.FindWithTag("notPlayer");
        }*/
       
       
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("notPlayer"))
        {
            input.SetActive(false);
            other.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            
            bglight.GetComponent<Light2D>().intensity = 0.17f;
            nearlamp1.GetComponent<Light2D>().intensity = 0.25f;
            nearlamp2.GetComponent<Light2D>().intensity = 0.25f;
            nearenemy1.SetActive(false);
            nearenemy2.SetActive(false);
            nearenemy3.SetActive(false);
            startToDrag.SetActive(false);

            enemytut.SetActive(true);
            tutLight.SetActive(true);
            other.GetComponent<Light2D>().intensity = 0.1f;
            arrow.SetActive(true);
            avoid.SetActive(true);
            
            Invoke("backToNormal", 4);

        }
    }
    void backToNormal()
    {
        input.SetActive(true);
       

        bglight.GetComponent<Light2D>().intensity = 0.3f;
        nearlamp1.GetComponent<Light2D>().intensity = 0.7f;
        nearlamp2.GetComponent<Light2D>().intensity = 0.7f;
        nearenemy1.SetActive(true);
        nearenemy2.SetActive(true);
        nearenemy3.SetActive(true);
        player.GetComponent<Light2D>().intensity = 1;
        
        Destroy(this); //destroy collider
        Destroy(tutLight);
        arrow.SetActive(false);
        avoid.SetActive(false);
       
    }


}
