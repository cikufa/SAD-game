using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Oneway : MonoBehaviour
{
    private SpriteRenderer sr1, sr2, sr3;
    private BoxCollider2D box1, box2, box3;

    public GameObject door2, door3;

    public GameObject FollowEnemy;
    // Start is called before the first frame update
    void Start()
    {
        //this.sr1 = this.GetComponent<SpriteRenderer>();
        //this.sr2 = door2.GetComponent<SpriteRenderer>();
        //this.sr3 = door3.GetComponent<SpriteRenderer>();

        box1 = this.GetComponent<BoxCollider2D>();
        box2 = door2.GetComponent<BoxCollider2D>();
        box3 = door3.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            this.GetComponent<SpriteRenderer>().enabled = true;
            door2.GetComponent<SpriteRenderer>().enabled = true;
            door3.GetComponent<SpriteRenderer>().enabled = true;
            FollowEnemy.SetActive(true);
            //this.sr1.enabled = true;
            //this.sr2.enabled = true;
            //this.sr3.enabled = true;
            box1.isTrigger = false;
            box2.isTrigger = false;
            box3.isTrigger = false;
        }
    }
}
