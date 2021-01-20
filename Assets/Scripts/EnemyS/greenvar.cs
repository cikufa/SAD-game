using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class greenvar : MonoBehaviour
{
	public Light2D light;
	private CircleCollider2D itsCollider;
	private double upLimit = 5f;
	private double downLimit = 3f;
	//public float innerrPlus=0.1f;
	private float outerPlus = 0.1f;
	private float colliderPlus = 0.02f;
	public float time = 0.1f;
	public bool shouldGetBigger = true;

	// Start is called before the first frame update
	void Start()
	{
		itsCollider = gameObject.GetComponent<CircleCollider2D>();
		StartCoroutine(DoEveryFelanSeconds());
	}
	IEnumerator DoEveryFelanSeconds()
	{
		while (true)
		{
			yield return new WaitForSeconds(time);
			DoSomething();
		}
	}
	void DoSomething()
	{
		CheckShoudGrow();
		if (shouldGetBigger)
		{
			GetBigger();
			//Debug.Log("Plusing");
		}
		else
		{
			GetSmaller();
			//Debug.Log("Minusing");
		}
	}
	void CheckShoudGrow()
	{
		if (light.pointLightOuterRadius < downLimit)
			shouldGetBigger = true;
		else if (light.pointLightOuterRadius > upLimit)
			shouldGetBigger = false;
	}
	void GetBigger()
	{
		light.pointLightOuterRadius += (float)outerPlus;
		itsCollider.radius += (float)colliderPlus;
	}
	void GetSmaller()
	{
		light.pointLightOuterRadius -= (float)outerPlus;
		itsCollider.radius -= (float)colliderPlus;
	}
}

