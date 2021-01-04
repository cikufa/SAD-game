using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;

    //Camera cam;
    public bool zoomIn = false;
    public bool zoomOut = false;
    public float value;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;

            if (zoomIn)
            {
                StartCoroutine(StartZoomIn());
            }
            else if (zoomOut)
            {
                StartCoroutine(StartZoomOut());
            }

            GetComponent<Collider2D>().enabled = false;            
        }
    }


    IEnumerator StartZoomIn()
    {
        float t = 0;
        float startZoom = cinemachine.m_Lens.OrthographicSize;

        while (t < 1)
        {
            t += Time.deltaTime * speed;
            //Debug.Log(cam.orthographicSize +" = "+value);
            cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, value, t );
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator StartZoomOut()
    {
        float t = 0;
        float startZoom = cinemachine.m_Lens.OrthographicSize;

        while (t < 1)
        {
            t += Time.deltaTime * speed;
            // Debug.Log(cinemachine.m_Lens.OrthographicSize +" = "+value);
            cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, value, t);
            yield return new WaitForEndOfFrame();
        }
    }

}
