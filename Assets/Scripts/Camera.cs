using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public float speed = 0.5f;
	public Vector3 Offset;
	public Transform player;

    void Update ()
	{ 
		Vector3 cameraStartPos = player.position + Offset;
		Vector3 cameraFinishPos = Vector3.Lerp(transform.position, cameraStartPos, speed*Time.deltaTime);
		transform.position = cameraFinishPos;
	}
}