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
    public static float shieldTime=18;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.tag == "shieldItem")
        {
            shieldactive = true;
            other.GetComponent<CircleCollider2D>().isTrigger = false;
            other.transform.position = transform.position;
            other.transform.parent = transform;
            SR.sortingLayerName = "ignore light";
            Invoke("bubblePop", shieldTime);
        }
    }
    public void bubblePop()
    {  
        SR.sortingLayerName = "default";
        shieldactive = false;

    }

}
