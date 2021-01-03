using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnim : MonoBehaviour
{
    public Animator generalAnim;

    public void AnimationEnded()
    {
        generalAnim.SetTrigger("LightStart");
    }
}
