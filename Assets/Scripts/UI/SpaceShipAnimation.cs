using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAnimation : MonoBehaviour
{
    public Animator generalAnim;
    public Animator playerAnim;
    public Transform ball;

    public void AnimationEnded()
    {
        generalAnim.SetTrigger("SpaceshipStart");
    }

    public void CallPlayerPull()
    {
        playerAnim.SetTrigger("pull");
    }

    public void ShootBall()
    {
        Debug.Log("SHOOT");
        ball.SetParent(transform.parent);
        ball.GetComponent<Animator>().enabled = true;
    }

    public void MakeBallBlack()
    {
        ball.GetComponent<SpriteRenderer>().color = Color.black;
    } 



}
