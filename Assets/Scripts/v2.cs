using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class v2 : MonoBehaviour
{
	public Light2D light;
	public float innerrPlus=0.5f;
	public float outerPlus = 0.5f;
	//public float time;
	public float upLimit = 5f;
	public float downLimit = 1f;
	public bool shouldGetBigger = false;
	//public CircleCollider2D itsCollider;
	// Update is called once per frame
	void Update()
	{
		CheckShoudGrow();
		while (shouldGetBigger)
		{
			GetBigger();
			Debug.Log("Plusing");
		}
		while(!shouldGetBigger)
		{
			GetSmaller();
			Debug.Log("Minusing");
		}
	}
	void CheckShoudGrow()
	{
		if (light.pointLightOuterRadius < upLimit)
			shouldGetBigger = true;
		else
			shouldGetBigger = false;
	}
	void GetBigger()
	{
		light.pointLightOuterRadius += (float)outerPlus;
		//itsCollider.radius += (float)0.01;
	}
	void GetSmaller()
	{
		light.pointLightOuterRadius -= (float)outerPlus;
		//itsCollider.radius -= (float)0.01;
	}
}
