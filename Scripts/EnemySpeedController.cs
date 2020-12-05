using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    // Start is called before the first frame update

    public static float leftrightspeed = 5f;
    public static float downrotatorspeed = 1f;
    public static float rotatespeed = 1f;
    public static float uprotatespeed = 1f;
    public static float leftrotatespeed = 1f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            leftrightspeed /= 2;
            downrotatorspeed /= 2;
            rotatespeed /= 2;
            uprotatespeed /= 2;
            leftrotatespeed /= 2;

            Invoke("ReturnToNormalSpeed", 5f);
        }


    }

    private void ReturnToNormalSpeed()
    {
        leftrightspeed *= 2;
        downrotatorspeed *= 2;
        rotatespeed *= 2;
        uprotatespeed *= 2;
        leftrotatespeed *= 2;
        Destroy(gameObject, 1f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
