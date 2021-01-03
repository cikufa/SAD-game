using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class tut : MonoBehaviour
{
    //public int tutNum;
    public GameObject bglight;
    
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
        if (other.CompareTag("Player"))
        {
            bglight.GetComponent<Light2D>().intensity = 0.2f;
            
            nearlamp1.GetComponent<Light2D>().intensity = 0.4f;
            nearlamp2.GetComponent<Light2D>().intensity = 0.4f;
            nearenemy1.SetActive(false);
            nearenemy2.SetActive(false);
            nearenemy3.SetActive(false);
            
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
            nearlamp1.GetComponent<Light2D>().intensity = 1;
            nearlamp2.GetComponent<Light2D>().intensity = 1;
            nearenemy1.SetActive(true);
            nearenemy2.SetActive(true);
            nearenemy3.SetActive(true);
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
