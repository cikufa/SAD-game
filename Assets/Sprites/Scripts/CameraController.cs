using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
	protected Transform myTransform;
	public float CamMoveSpeed = 5f;
	
	
	void FixedUpdate(){
		
		
		Vector3 camPosition = transform.position;
		
		Vector3 playerPosition = new Vector3(Player.position.x+5,Player.position.y,Player.position.z-2 );
		
		transform.position = Vector3.Lerp(camPosition, playerPosition,CamMoveSpeed * Time.deltaTime );
	}
}
