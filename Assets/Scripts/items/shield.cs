using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shield : MonoBehaviour
{
   
     //public float speed;
     //private int c = 2001;
     //private int k = 1;
     public Animator bubblepop;
    
     // Start is called before the first frame update
    /* 
    void Start()
     {
         c = 11;
         SR = GetComponent<SpriteRenderer>();
     }

     // Update is called once per frame
     void Update()
     {
         var randDir = Random.Range(1, 5);
         var randDir = Random.Range(1, 5);
         random move
         if (randDir == 4)
         {
              gameObject.transform.Translate(-Vector2.right * speed * Time.deltaTime);
              c++;
         }

         //Left
         if (randDir == 3)
         {
             gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
             c++;
         }
               //Up
         if (randDir == 2)
         {
              gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
              c++;
          }

         //Down
         if (randDir == 1)
         {
             gameObject.transform.Translate(-Vector2.up * speed * Time.deltaTime);
             c++;
         }
     }
    */
     void OnTriggerEnter2D(Collider2D other)
     {
         
         if (other.tag != "player")
         {    
             Invoke("pop", testShield.shieldTime);     
         }
     }

     void pop()
     {
         bubblepop.SetBool("pop", true);
         Invoke("byeBubble",1.1f);
         
     }
     void byeBubble()
     {
         gameObject.SetActive(false);
         bubblepop.SetBool("pop", false);

     }


}
    