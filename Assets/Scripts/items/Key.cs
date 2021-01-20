using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Key : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject itself;
    public Light2D child;
    private bool what = true;
    public float time1 = 2f;
    public float time2 = 5f;
    public static float endTime = 20f;
    //public float sec = 1f;
    //private Light child;
    void Start()
    {
        StartCoroutine(DoEveryFelanSeconds());
        EventBroker.GameOver += PlayerRespawn;        
    }
    /* void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.tag == "Player")
         {
             //Destroy(itself.gameObject);
             itself.gameObject.SetActive(false);
             what = itself.activeInHierarchy;
             Debug.Log(itself.activeInHierarchy);
             Debug.Log(itself.activeSelf);
         }
   
         IEnumerator LateCall()
         {
             yield return new WaitForSeconds(sec);
             if (!what)
             {
                 Debug.Log("here");
                 foreach (GameObject l in lights)
                 {
                     Debug.Log("H");
                     l.gameObject.SetActive(false);
                     //child=l.transform.GetChild(0).gameobject;
                     //child.intensity = 0;
                     //itslight.intensity = intensity;
                     //GetComponent<Renderer>().enabled = false;
                 }
             }
             else
                 Debug.Log("not");
         }
    */

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag=="notPlayer")
        {
            //Debug.Log("entered");
            //gameObject.SetActive(false);
            child.intensity = 0;
            GetComponent<Renderer>().enabled = false;
            transform.GetChild(0).GetComponent<AudioSource>().Stop();
            what = false;
            Invoke("end", endTime);
            StopCoroutine(DoEveryFelanSeconds());
        }
        
    }
    IEnumerator DoEveryFelanSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(time1);
            DoSomething();
            yield return new WaitForSeconds(time2);
            DoSomething2();
        }
    }

    // happens every 0.5 seconds
    void DoSomething()
    {
        //Debug.Log("d1");
        if (!what)
        {
            foreach (GameObject l in lights)
            {
                l.gameObject.SetActive(false);
            }
        }
    }
    void DoSomething2()
    {
        //Debug.Log("d2");
        if (!what)
        {
            foreach (GameObject l in lights)
            {
                l.gameObject.SetActive(true);
            }
        }
    }
    public void end()
    {
        gameObject.SetActive(false);
    }

    void PlayerRespawn()
    {
        //Debug.Log("heeeeeeeeey");
        if (IsInvoking())
        {
            CancelInvoke();
        }
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventBroker.GameOver -= PlayerRespawn;
    }
}

