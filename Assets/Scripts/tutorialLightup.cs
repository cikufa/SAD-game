using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class turorialLightup : MonoBehaviour
{
    public int tutNum;
    public GameObject bglight;
    public GameObject lamps;
    public GameObject Enemies;
    public GameObject enemytut;
    public GameObject tutLight;
    // Start is called before the first frame update
    void Start()
    {
        //tutLight= this.GetComponent<Light2D>();   
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bglight.GetComponent<Light2D>().intensity = 0.15f;
            lamps.GetComponent<Light2D>().intensity = 0.1f;
            Enemies.SetActive(false);
            enemytut.SetActive(true);
            tutLight.SetActive(true);
            /*switch (tutNum)
            {
                case 1:
                    ctetut.SetActive(true);
                    ctetut.transform.GetChild(1).gameObject.SetActive(true);
                    break;

                case 2:
                    LRtut.SetActive(true);
                    LRtut.transform.GetChild(1).gameObject.SetActive(true);
                    break;

                case 3:
                    rotate360tut.SetActive(true);
                    rotate360tut.GetComponent<Light2D>().enabled = true;
                    break;

                case 4:
                    variabletut.SetActive(true);
                    variabletut.GetComponent<Light2D>().enabled = true;
                    break;

            }*/
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bglight.GetComponent<Light2D>().intensity = 0.3f;
            lamps.GetComponent<Light2D>().intensity = 1;
            Enemies.SetActive(true);
            Destroy(this); //destroy collider
            Destroy(tutLight);
           
            /*switch (tutNum)
            {
                case 1:
                    ctetut.GetComponent<Light2D>().enabled = false;
                    break;
                case 2:
                    LRtut.GetComponent<Light2D>().enabled = false;
                    break;
                case 3:
                    rotate360tut.GetComponent<Light2D>().enabled = false;
                    break;
                case 4:
                    variabletut.GetComponent<Light2D>().enabled = false;
                    break;
            }*/
        }
    }

}