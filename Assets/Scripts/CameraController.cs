using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	public Vector3 cameraOffset;

	void Start()
	{
		cameraOffset = this.transform.position - player.transform.position;
		Debug.Log(cameraOffset);
	}

	void LateUpdate ()
	{
		if (player != null)
		{
			this.transform.position = player.transform.position + cameraOffset;
		}
	}
}
