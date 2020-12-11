using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ne : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float limit = 4f;
	private float rightLimit ;
	private float leftLimit ;
	public bool shouldGoRight = false;

	Vector3 pos, localScale;
	// Start is called before the first frame update
	void Start()
	{
		pos = transform.position;
		localScale = transform.localScale;
		leftLimit = pos.x - limit;
		rightLimit = pos.x + limit;
	}

	// Update is called once per frame
	void Update()
	{
		CheckWhereToGo();
		if (shouldGoRight)
		{
			MoveRight();
		}
		else
		{
			MoveLeft();
		}
	}
	void CheckWhereToGo()
	{
		if (pos.x < leftLimit)
			shouldGoRight = true;

		else if (pos.x > rightLimit)
			shouldGoRight = false;

		if (((shouldGoRight) && (localScale.x < 0)) || ((!shouldGoRight) && (localScale.x > 0)))
		localScale.x *= -1;

		transform.localScale = localScale;

	}

	void MoveRight()
	{
		pos += transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos;
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos;
	}

}
