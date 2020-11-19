using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downRotator : MonoBehaviour
{
    /*
     * pendulum:
     * 
     * public Rigidbody2D body2d;
        public float leftRange;
        public float rightRange;
        public float velocityThresh;
 
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThresh;
    }
    void Update()
    {
        push();

    }
    void push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightRange
            && body2d.angularVelocity > 0 && body2d.angularVelocity < velocityThresh)
        {
            body2d.angularVelocity = velocityThresh;
        }
        else if (transform.rotation.z > 0 && transform.rotation.z < rightRange
           && body2d.angularVelocity > 0 && body2d.angularVelocity < velocityThresh)
        {
            body2d.angularVelocity = -1 * velocityThresh;
        }
    }
*/

    //mine 
 
    
    public float speed;
    public float leftRange; //-0.5
    public float rightRange; //0.5
    int phase = 1;
    
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (phase == 1){
            transform.Rotate(0f, 0f, speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= rightRange)
            {
                phase = 2;
            }
        }
            
        else if (phase == 2)
        {
            transform.Rotate(0f, 0f, -speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= 0.02)
            {
                phase = 3;
            }
        }
        else if (phase == 3)
        {
            transform.Rotate(0f, 0f, -speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= leftRange)
            {
                phase = 4;
            }
        }
        else if (phase == 4)
        {
            transform.Rotate(0f, 0f, speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= -0.02)
            {
                phase = 1;
            }
        }
           
    }
              
    

        /*
         * no physics pendulum: 
  
    float timer = 0f;
    float speed=1.2f;
    int phase = 0;
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > 1f)
        {
            phase++;
            phase %= 4;
            timer = 0;
        }
        switch (phase)
        {
            case 0:
                transform.Rotate(0f, 0f, speed*(1-timer));
                break;
            
            case 1:
                transform.Rotate(0f, 0f, -speed* timer);
                break;
                
            case 2:
                transform.Rotate(0f, 0f, -speed*(1-timer));
                break;
            case 3:
                transform.Rotate(0f, 0f, speed * timer);
                break;

        }

    }
       
         * */

}
