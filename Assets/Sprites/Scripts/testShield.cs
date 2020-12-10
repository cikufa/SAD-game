using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to player with shield or shield
public class testShield : MonoBehaviour
{
    //public GameObject Player;
    public static bool shieldactive;
    private SpriteRenderer SR;
    public GameObject shield;
    public static float shieldTime=5;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
       // bubblepop = shield.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shieldItem")
        {
            Debug.Log("shields on");
            //other.GetComponent<Renderer>().enabled = false;
            
            shieldactive = true;
            other.transform.position = transform.position;
            other.transform.parent = transform;
            SR.sortingLayerName = "ignore light";
            /*while (Time.deltaTime < 10)
            {
                Debug.Log(Time.deltaTime);
            }
             * */
            Invoke("bubblePop", shieldTime);

        }

    }
    public void bubblePop()
    {
        //anim bubble pop
        //bubblepop.SetBool("pop", true);       
        //shield.gameObject.SetActive(false);
        SR.sortingLayerName = "default";
        shieldactive = false;

    }

}
