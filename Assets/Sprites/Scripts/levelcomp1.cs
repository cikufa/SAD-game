using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class levelcomp1 : MonoBehaviour
{
    public GameObject character;
    private Transform charT;
    private Animator holdBallAnimator;
    Vector3 charScale;
    public GameObject yellowBall;
    private SpriteRenderer ballSR;
    private Transform ballT;
    //private Light2D ballLight;

    public GameObject colorLight1;
    //public GameObject colorLight2;
    UnityEngine.Experimental.Rendering.Universal.Light2D light1;
    //UnityEngine.Experimental.Rendering.Universal.Light2D light2;
    private int onetime, onetime2;

    [Space]
    public GameObject button;

    void Start()
    {

        light1 = colorLight1.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        
        charT = character.GetComponent<Transform>();
        //ballLight = yellowBall.GetComponent<Light2D>();
        ballSR = yellowBall.GetComponent<SpriteRenderer>();
        ballT = yellowBall.GetComponent<Transform>();
        //ballSR.SetActive(false);
        holdBallAnimator = character.GetComponent<Animator>();

        charScale = new Vector3(140, 140, 0);
        onetime = 0;
        onetime2 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //char gets bigger
        if (charT.localScale.x < charScale.x & charT.localScale.y < charScale.y)
        {
            charT.localScale += new Vector3(0.1f, 0.1f, 0);

        }
        //else if (charT.localScale.x >= charScale.x & charT.localScale.y >= charScale.y)
        //{
            //holdBallAnimator.SetBool("hold", true);
            //ball apears
            //yellowBall.SetActive(true);
            //ballAnimator.SetBool(true);
            // nore ball kam ziad she how?
            //dont enter again
            //charT.localScale += new Vector3(10, 10 ,0);

        //}
        //light spreads
        if (light1.pointLightInnerRadius > 0.3)
        {
            light1.pointLightInnerRadius -= 0.002f;
           
        }
        if (light1.pointLightOuterRadius > 0.4)
        {
            light1.pointLightOuterRadius -= 0.006f;
            light1.intensity += 0.0001f;
           
        }
        
        if (light1.pointLightOuterRadius <= 0.4 & onetime==0)
        {
            yellowBall.SetActive(true);
            onetime = 1;
            ballSR.sortingLayerName = "ignore light";
        }
        if (onetime == 1 & ballT.position.y > -1.5f)
        {
            colorLight1.SetActive(false);
            ballT.position -= new Vector3(0, 0.004f, 0);
            if (ballT.position.y <= -0.9f & onetime2 == 0)
            {
                holdBallAnimator.SetBool("hold", true);
                onetime2 = 1;
            }
            
        }

        button.SetActive(true);

    }
}
