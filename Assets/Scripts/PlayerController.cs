using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam;
    public float forceConstant = 2;
    public AnimationCurve forceCurve;
    public float rotationSpeed;

    #region private fields
    Rigidbody2D rb;
    Vector3 start = Vector3.zero;
    Vector3 end = Vector3.zero;
    Vector3 dir = Vector3.zero;
    float dist = 0;
    float MaxDistance = 0;
    bool isDragging = false;
    Animator animator;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.right, Color.red);

        if (isDragging)
        {
            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotationDirection = -((mouseWorldPos - start).normalized);
            Debug.DrawRay(transform.position, rotationDirection, Color.blue);

            float angle = Mathf.Atan2(rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg;

            CheckAngleAndFlip(angle);


            Debug.Log("angle:  "+angle);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
       
    }

    IEnumerator CheckVelocity()
    {
        yield return new WaitForSeconds(.5f);

        while (rb.velocity.magnitude >= 2)
        {
            yield return new WaitForEndOfFrame();
        }
        animator.SetTrigger("EndAnimation");
    }

    public void StartAim(Vector2 pos)
    {
        start = mainCam.ScreenToWorldPoint(pos);
        animator.SetTrigger("clickON");
    }

    public void EndAim(Vector2 pos)
    {
        end = mainCam.ScreenToWorldPoint(pos);

        dir = (start - end).normalized;
        dist = (start - end).magnitude;
        Debug.Log("Dist : " + dist);
        float forceAmount = forceCurve.Evaluate(dist);
        rb.AddForce(dir * forceAmount * forceConstant);

        animator.SetTrigger("clickOFF");
        isDragging = false;

        StartCoroutine("CheckVelocity");
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

    public void DraggingStarted()
    {
        isDragging = true;
    }

    void CheckAngleAndFlip(float angle)
    {
        if(angle >= -90 && angle <= 90)
        {
            GetComponent<SpriteRenderer>().flipY= false;
        }
        else if((angle > 90 && angle <= 180) || (angle >= -180 && angle < -90))
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
    }
}
