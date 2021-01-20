using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class ResetFollow : MonoBehaviour
{
    public GameObject door1, door2, door3;

    public GameObject FollowEnemy;

    public GameObject l;

    AIPath p;
    // Start is called before the first frame update
    void Start()
    {
        p = FollowEnemy.GetComponent<AIPath>();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            door1.GetComponent<SpriteRenderer>().enabled = false;
            door2.GetComponent<SpriteRenderer>().enabled = false;
            door3.GetComponent<SpriteRenderer>().enabled = false;
            p.enabled = false;
            l.SetActive(false);
            FollowEnemy.SetActive(false);
            FollowEnemy.GetComponent<Transform>().position = new Vector3(390, -78, 0);
            FollowEnemy.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            door1.GetComponent<BoxCollider2D>().isTrigger = true;
            door2.GetComponent<BoxCollider2D>().isTrigger = true;
            door3.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
