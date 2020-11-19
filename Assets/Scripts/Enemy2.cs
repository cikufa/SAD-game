using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 5f;
	public float rightLimit = 7f;
	public float leftLimit = -7f;
	
	public Animator enemy2Anim;

	public bool shouldGoRight = true;

    Vector3 pos, localScale;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
		enemy2Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWhereToGo();
        if (shouldGoRight){
			enemy2Anim.SetBool("L/R", true);
            MoveRight();}
        else{
			enemy2Anim.SetBool("L/R", false);
            MoveLeft();}
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
