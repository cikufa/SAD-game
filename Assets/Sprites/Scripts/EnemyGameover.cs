using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameover : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject gameStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("collision");
        if (other.gameObject.tag == "Player" && gameStatus.tag != "won")
        {
            Debug.Log("Object entered");
            canvasObject.SetActive(true);
            gameStatus.tag = "lost";
        }

    }









}
