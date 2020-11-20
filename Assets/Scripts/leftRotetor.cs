using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftRotetor : MonoBehaviour
{
    public float speed;
    public float upRange; //-0.95
    public float downRange; //-0.05
    int phase = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (phase == 1)
        {
            transform.Rotate(0f, 0f, -speed);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= upRange)
            {
                phase = 2;
            }
        }

        else if (phase == 2)
        {
            transform.Rotate(0f, 0f, speed);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= -0.5)
            {
                phase = 3;
            }
        }
        else if (phase == 3)
        {
            transform.Rotate(0f, 0f, speed);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= downRange)
            {
                phase = 4;
            }
        }
        else if (phase == 4)
        {
            transform.Rotate(0f, 0f, -speed);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= -0.5)
            {
                phase = 1;
            }
        }
        
    }
}
