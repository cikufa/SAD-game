using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class v2 : MonoBehaviour
{
   public Light2D light;
	public float innerrPlus;
	public float outerPlus;
	public float time;
	public float moveSpeed = 5f;
    public float upLimit = 7f;
    public float downLimit = 0f;
    public bool shouldGetBigger = false;
    // Update is called once per frame
    void Update()
    {
		CheckShoudGrow();
		if (shouldGetBigger)
		{
			GetBigger();
		}
		else
		{
			GetSmaller();
		}
	}
	void CheckShoudGrow()
	{
		if (light.pointLightOuterRadius< upLimit)
			shouldGetBigger = true;
		else if (light.pointLightOuterRadius > downLimit)
			shouldGetBigger = false;
	}
	void GetBigger()
	{
		light.pointLightOuterRadius += (float)outerPlus * Time.deltaTime;
	}
	void GetSmaller()
	{
		light.pointLightOuterRadius -= (float)outerPlus * Time.deltaTime;
	}
}
