using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam;
    public float forceConstant = 2;
    public AnimationCurve forceCurve;

    #region private fields
    Rigidbody2D rb;
    Vector3 start = Vector3.zero;
    Vector3 end = Vector3.zero;
    Vector3 dir = Vector3.zero;
    float dist = 0;
    float MaxDistance = 0;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartAim(Vector2 pos)
    {
        start = mainCam.ScreenToWorldPoint(pos);
    }

    public void EndAim(Vector2 pos)
    {
        end = mainCam.ScreenToWorldPoint(pos);

        dir = (start - end).normalized;
        dist = (start - end).magnitude;
        Debug.Log("Dist : " + dist);
        float forceAmount = forceCurve.Evaluate(dist);
        rb.AddForce(dir * forceAmount * forceConstant);
    }

    public void SetMaxDistance(Vector2 top_left,Vector2 bottom_right)
    {
        Vector3 a = mainCam.ScreenToWorldPoint(top_left);
        a.z = 0;
        Vector3 b = mainCam.ScreenToWorldPoint(bottom_right);
        b.z = 0;
        MaxDistance = (a - b).magnitude;

        Keyframe kEnd = forceCurve.keys[1];
        kEnd.time = MaxDistance;
        forceCurve.RemoveKey(1);
        forceCurve.AddKey(kEnd);
        forceCurve.SmoothTangents(1, 10);
    }
}
