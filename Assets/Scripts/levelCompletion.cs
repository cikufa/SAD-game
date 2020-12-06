using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;
public class levelCompletion : MonoBehaviour
{
    public GameObject character;
    private Transform charT;
    private Animator holdBallAnimator;
 
    public GameObject yellowBall;
    private SpriteRenderer ballSR;
    private Light2D ballLight;

    public GameObject colorLight;
    private Light2D light;
    Vector3 charScale;
   
    
    // Start is called before the first frame update
    void Start()
    {
        charT= character.GetComponent<Transform>();
        ballLight = yellowBall.GetComponent<Light2D>();
        ballSR = yellowBall.GetComponent<SpriteRenderer>();
        light = colorLight.GetComponent<Light2D>(); 
        //ballSR.SetActive(false);
        holdBallAnimator = character.GetComponent<Animator>();

        charScale = new Vector3(110, 110, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
  
        //char gets bigger
        if (charT.localScale.x < charScale.x & charT.localScale.y < charScale.y)
        {
            charT.localScale += new Vector3(10, 10, 0);

        }
        else if (charT.localScale.Equals(charScale))
        {
            holdBallAnimator.SetBool("hold", true);
            //ball apears
            yellowBall.SetActive(true);
            //ballAnimator.SetBool(true);
            // nore ball kam ziad she how?
            //dont enter again
            charT.localScale += new Vector3(10, 10 ,0);

        } 
        //light spreads
        if (light.pointLightInnerRadius < 2 && light.pointLightOutererRadius < 7)
        {

            light.pointLightInnerRadius.set(0.02);
            light.pointLightOuterRadius += 0.07;
        }
        // yrllow ball appears
    }
}
