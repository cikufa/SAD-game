using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Invisible : MonoBehaviour
{

    public Light2D itslight;
    private GameObject player;
    float distance;
    public float intensity = 3f;
    public float sight = 10f;
    private Animator animator;
    //public UnityEngine.Experimental.Rendering.LWRP.Light2D itsLight;
    void Start()
    {
        //light = Light.Find("Circle Light");
        player = GameObject.FindWithTag("Player");
        //box = GameObject.Find("Parent Circle Light");
        //box.gameObject.SetActive(true);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        distance = GetDist();
        //float distance = Vector3.Distance(target.position,transform.position);
        if (distance < sight)
        {

            animator.SetBool("appear", true);
            
            if (itslight.intensity < intensity)
            {
                itslight.intensity += 0.5f;
            }
            //itslight.intensity = intensity;
            GetComponent<Renderer>().enabled = true;
     
        }
        else if (distance > sight)
        {
            itslight.intensity = 0;
            GetComponent<Renderer>().enabled = false ;
         
        }
    }
    float GetDist()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
/*
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        box.gameObject.SetActive(true);
    }
}

void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        box.gameObject.SetActive(false);
    }
}
}
float distance;
//public GameObject player;
Transform target;
//public Renderer rend;
public float sight=5;
Renderer rend=GetComponent<Renderer>();
// Start is called before the first frame update
void Start()
{
    target = GameObject.FindWithTag("Player").transform ;
    //gameObject.SetActive(true);
    //distance = Vector3.Distance(transform.position, target.position);
}

// Update is called once per frame
void Update()
{
    distance=Getdist();
    //float distance = Vector3.Distance(target.position,transform.position);
    if (distance < sight)
    {
        rend.enabled = true;
        Debug.Log("hey");
    }
    else if (distance > sight)
    {
        rend.enabled = false;
        Debug.Log("123");
    }
}
}
float GetDist()
{
return Vector3.Distance(transform.position, target.position);
}
void OnTriggerEnter2D(Collider2D other)
{
if (other.gameObject.tag == "Player")
{
    Debug.Log("player's nearby");
    .SetActive(true);
}
*/