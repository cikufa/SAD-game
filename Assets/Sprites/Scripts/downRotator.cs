using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downRotator : MonoBehaviour
{
    public float leftRange; //-0.5
    public float rightRange; //0.5
    int phase = 1;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (phase == 1)
        {
            transform.Rotate(0f, 0f, EnemySpeedController.downrotatorspeed * Time.deltaTime);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= rightRange)
            {
                phase = 2;
            }
        }

        else if (phase == 2)
        {
            transform.Rotate(0f, 0f, -EnemySpeedController.downrotatorspeed * Time.deltaTime);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= 0.02)
            {
                phase = 3;
            }
        }
        else if (phase == 3)
        {
            transform.Rotate(0f, 0f, -EnemySpeedController.downrotatorspeed * Time.deltaTime);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= leftRange)
            {
                phase = 4;
            }
        }
        else if (phase == 4)
        {
            transform.Rotate(0f, 0f, EnemySpeedController.downrotatorspeed * Time.deltaTime);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= -0.02)
            {
                phase = 1;
            }
        }

    }



}
