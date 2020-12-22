using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Oneway : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D box;
    public GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            follow.SetActive(true);
            this.spriteRenderer.enabled = true;
            this.box.isTrigger = false;
        }
    }
}
