using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gameover : MonoBehaviour
{
	public GameObject canvasObject;
    public GameObject gameStatus;
	
    void Start() {
        Debug.Log("Start");
        //gameStatus.tag = "Untagged";
    }
    void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player" &&  gameStatus.tag != "won"){
			Debug.Log("Object entered");
			canvasObject.SetActive(true);
            gameStatus.tag = "lost";
		}
		
	}

  
    
}
