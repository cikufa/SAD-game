using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKevin : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    public Vector3 finalScale;
    public float speed=1;
    [HideInInspector]
    public bool shoot = false;
    bool firstTime = true;

    //void FixedUpdate()
    //{
    //    if (!shoot)
    //    {
    //        transform.position = Player.transform.position + offset;
    //        transform.localScale = Vector3.MoveTowards(transform.localScale, finalScale, Time.fixedDeltaTime * speed);
    //    }
    //    else if(shoot && firstTime)
    //    {
    //        GetComponent<Animator>().SetTrigger("go");
    //        firstTime = false;
    //        return;
    //    }
    //}
}
