using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
//using UnityEngine.Experimental.Rendering.LWRP;

public class InvisibleLight : MonoBehaviour
{
    public Light2D light;
    private GameObject player;
    float distance;
    public float sight = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = GetDist();
        if (distance < sight)
        {
            //GetComponent<Renderer>().enabled = true;
            light.intensity = 3;
            //itsLight.enable = true;
            //light.light.enabled = true;
            //Debug.Log("hey");
        }
        else if (distance > sight)
        {
            //GetComponent<Renderer>().enabled = false;
            light.intensity = 0;

            //itsLight.enable = false;
            //light.light.enabled=false;
            //Debug.Log("123");
        }
    }
    float GetDist()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
