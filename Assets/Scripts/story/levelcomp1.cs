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

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    [Space]
    public GameObject button;
    public Transform enemyManager;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.PlayOneShot(sound);

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
            charT.localScale += new Vector3(0.15f, 0.15f, 0);

        }
      
        //light spreads
        if (light1.pointLightInnerRadius > 0.3)
        {
            light1.pointLightInnerRadius -= 0.003f;

        }
        if (light1.pointLightOuterRadius > 0.4)
        {
            light1.pointLightOuterRadius -= 0.008f;
            light1.intensity += 0.0002f;

        }

        if (light1.pointLightOuterRadius <= 0.4 & onetime == 0)
        {
            yellowBall.SetActive(true);
            onetime = 1;
            ballSR.sortingLayerName = "ignore light";
        }
        if (onetime == 1 & ballT.position.y > -1.5f)
        {
            colorLight1.SetActive(false);
            ballT.position -= new Vector3(0, 0.007f, 0);
            if (ballT.position.y <= 0.8f & onetime2 == 0)
            {
                holdBallAnimator.SetBool("hold", true);
                onetime2 = 1;
                button.SetActive(true);
                enemyManager.GetComponent<EnemyInCompletionLevel>().Explode();
            }

        }



    }
}
