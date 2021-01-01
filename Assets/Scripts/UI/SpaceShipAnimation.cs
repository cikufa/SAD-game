using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAnimation : MonoBehaviour
{
    public Animator generalAnim;

    public void AnimationEnded()
    {
        generalAnim.SetTrigger("EarthStart");
    }
}
