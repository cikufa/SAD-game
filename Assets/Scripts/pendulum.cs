using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRotator : MonoBehaviour
{
    public Rigidbody2D body2d;
    public float leftRange;
    public float rightRange;
    public float velocityThresh;

 /*
    public float speed;
    private float angle=0;
    private float cangle = 1;
    
    void Start()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * 10 * speed);
    }
    
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0f, 0f, 1f) * speed * Time.deltaTime);
         angle = angle % 4*cangle;
         //transform.Rotate(new Vector3(0f, 0f, 1f) * angle * speed);
         //angle = angle % 20;
         if (angle < 2*cangle){
            transform.Rotate(new Vector3(0f, 0f, -1f) *10);
            Debug.Log(angle);
         }
         else 
         {
             transform.Rotate(new Vector3(0f, 0f, 1f)*10);
             Debug.Log(angle);
         }
         angle += 1;
        
      /*
        t = (Time.time *100) % 5;
        if (t< 1)
        {
            transform.Rotate(new Vector3(0f, 0f, 1f) * speed * t);
        }
        else if (t>1)
        {
            speed = -1 * speed;
            transform.Rotate(new Vector3(0f, 0f, 1f) * speed * (t-5));
        }
      
    }
*/
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
}
