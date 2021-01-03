using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator generalAnim;

    public void AnimationEnded()
    {
        generalAnim.SetTrigger("BlackStart");
    }
}
