using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class VariableLight : MonoBehaviour
{
    public Light2D light;
    public double upLimit;
    public double downLimit;
    public float innerrPlus;
    public float outerPlus;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(DoEveryFelanSeconds());
    }
    IEnumerator DoEveryFelanSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(EnemySpeedController.time);
            DoSomething();
            yield return new WaitForSeconds(EnemySpeedController.time);
            DoSomething2();
        }
    }
    void DoSomething()
    {
        while (light.pointLightOuterRadius < upLimit)
        {

            //light.pointLightInnerRadius += (float)rPlus;
            light.pointLightOuterRadius += (float)outerPlus;
            Debug.Log("Plusing");
        }
    }
    void DoSomething2()
    {
        while (light.pointLightOuterRadius > downLimit)
        {
            light.pointLightOuterRadius -= (float)outerPlus;
            Debug.Log("Minusing");
        }
    }
    /* if(light.pointLightOuterRadius > downLimit)
     {
         //light.pointLightInnerRadius -= (float)rPlus;
         light.pointLightOuterRadius -= (float)Rplus;

     }
    */
}
