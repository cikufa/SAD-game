using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class laser : MonoBehaviour
{
	public Light2D light;
	private BoxCollider2D itsCollider;
	public double upLimit = 5f;
	public double downLimit = 2f;
	//public float innerrPlus=0.1f;
	public float outerPlus = 0.1f;
	public float innerPlus = 0.07f;
	public float colliderPlus = 0.04f;
	public float time = 0.1f;
	public bool shouldGetBigger = true;

	// Start is called before the first frame update
	void Start()
	{
		itsCollider = gameObject.GetComponent<BoxCollider2D>();
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
		}
		else
		{
			GetSmaller();
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
		light.pointLightInnerRadius += (float)innerPlus;
		itsCollider.size += new Vector2(0, colliderPlus);
			
	}
	void GetSmaller()
	{
		light.pointLightOuterRadius -= (float)outerPlus;
		light.pointLightInnerRadius -= (float)innerPlus;
		itsCollider.size -= new Vector2(0, colliderPlus);
			
	}
}

