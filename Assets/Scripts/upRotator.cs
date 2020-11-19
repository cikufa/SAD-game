using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upRotator : MonoBehaviour
{

    public float speed;
    public float leftRange; //0.8
    public float rightRange; //0.8
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
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= rightRange)
            {
                phase = 2;
            }
        }

        else if (phase == 2)
        {
            transform.Rotate(0f, 0f, speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= 0.99)
            {
                phase = 3;
            }
        }
        else if (phase == 3)
        {
            transform.Rotate(0f, 0f, speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= leftRange)
            {
                phase = 4;
            }
        }
        else if (phase == 4)
        {
            transform.Rotate(0f, 0f, -speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= 0.99)
            {
                phase = 1;
            }
        }
        
    }
}
