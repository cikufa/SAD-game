using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : MonoBehaviour
{

    public float upLimit = 7f;
    public float downLimit = -7f;
    public Animator enemy2animator;
    public bool shouldGoUp = false;

    Vector3 pos, localScale;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWhereToGo();
        if (shouldGoUp)
        {
            enemy2animator.SetBool("L/R", true);
            MoveUp();
        }
        else
        {
            enemy2animator.SetBool("L/R", false);
            MoveDown();
        }
    }
    void CheckWhereToGo()
    {
        if (pos.y < downLimit)
            shouldGoUp = true;

        else if (pos.y > upLimit)
            shouldGoUp = false;

        //if (((shouldGoRight) && (localScale.x < 0)) || ((!shouldGoRight) && (localScale.x > 0)))
        //localScale.x *= -1;

        //transform.localScale = localScale;

    }

    void MoveUp()
    {
        pos += Vector3.up * Time.deltaTime * EnemySpeedController.leftrightspeed;
        transform.position = pos;
    }

    void MoveDown()
    {
        pos -= Vector3.up * Time.deltaTime * EnemySpeedController.leftrightspeed;
        transform.position = pos;
    }

}

