using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam;
    public float forceConstant = 2;
    public AnimationCurve forceCurve;
    public float rotationSpeed;
    public VariableJoystick variableJoystick;
    public float brakeSpeed = 1;

    [HideInInspector]
    public int life = 3;
    [HideInInspector]
    public bool hasLost = false;

    #region private fields
    Rigidbody2D rb;
    Vector3 start = Vector3.zero;
    Vector3 end = Vector3.zero;
    Vector3 dir = Vector3.zero;
    float dist = 0;
    float MaxDistance = 0;
    bool isDragging = false;
    Animator animator;
    bool brakeNow = false;

    #endregion

    private void Awake()
    {
        //mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        EventBroker.GameOver += GameOver;
        EventBroker.startAim += StartAim;
        EventBroker.endAim += EndAim;
        variableJoystick = GameObject.FindWithTag("Joystick").GetComponent<VariableJoystick>();

    }

    private void Update()
    {
        //Debug.Log(variableJoystick.Direction.normalized);
        //Debug.DrawRay(transform.position, transform.right, Color.red);
        Debug.DrawRay(transform.position, -variableJoystick.Direction.normalized, Color.red);

        if (!hasLost && isDragging)
        {
            //Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 rotationDirection = -((mouseWorldPos - start).normalized);
            //Debug.DrawRay(transform.position, rotationDirection, Color.blue);

            //Angle
            float angle = Mathf.Atan2((-variableJoystick.Direction.normalized).y, (-variableJoystick.Direction.normalized).x) * Mathf.Rad2Deg;
            CheckAngleAndFlip(angle);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Movement

        }

        if(!hasLost && brakeNow)
        {
             rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, Time.deltaTime * brakeSpeed);
            if(rb.velocity.magnitude == 0)
            {
                brakeNow = false;
            }
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
        animator.ResetTrigger("clickOFF");
        animator.ResetTrigger("clickON");
    }

    public void StartAim()
    {
        Debug.Log("starttttt");
        //start = mainCam.ScreenToWorldPoint(pos);
        isDragging = true;
        brakeNow = false;
        animator.SetTrigger("clickON");
        animator.ResetTrigger("clickOFF");
        animator.ResetTrigger("EndAnimation");
    }

    public void EndAim()
    {
        if (this.gameObject.activeSelf)
        {
            Debug.Log("enddddd");
            //end = mainCam.ScreenToWorldPoint(pos);

            //dir = (start - end).normalized;
            //dist = (start - end).magnitude;
            //Debug.Log("Dist : " + dist);
            //float forceAmount = forceCurve.Evaluate(dist);
            rb.AddForce(-variableJoystick.Direction.normalized * forceCurve.Evaluate(variableJoystick.Direction.magnitude) * forceConstant);
            Debug.Log(forceCurve.Evaluate(variableJoystick.Direction.magnitude));
            animator.SetTrigger("clickOFF");
            animator.ResetTrigger("clickON");
            animator.ResetTrigger("EndAnimation");
            isDragging = false;

            StartCoroutine("CheckVelocity");
        }
    }

    //public void SetMaxDistance(Vector2 top_left,Vector2 bottom_right)
    //{
    //    Vector3 a = mainCam.ScreenToWorldPoint(top_left);
    //    a.z = 0;
    //    Vector3 b = mainCam.ScreenToWorldPoint(bottom_right);
    //    b.z = 0;
    //    MaxDistance = (a - b).magnitude;

    //    Keyframe kEnd = forceCurve.keys[1];
    //    kEnd.time = MaxDistance;
    //    forceCurve.RemoveKey(1);
    //    forceCurve.AddKey(kEnd);
    //    forceCurve.SmoothTangents(1, 10);
    //}

    //public void DraggingStarted()
    //{
    //    isDragging = true;
    //}

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

    void GameOver()
    {
        hasLost = true;
    }

    private void OnDestroy()
    {
        EventBroker.GameOver -= GameOver;
        EventBroker.startAim -= StartAim;
        EventBroker.endAim -= EndAim;
    }

    public void Brake()
    {
        brakeNow = true;
        
    }
}
