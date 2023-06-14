using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed = 2f;
	private int score = 0;
	public int health = 5;

	private Rigidbody playerRigidBody;
	private void Start ()
	{
		playerRigidBody = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
		playerRigidBody.velocity = movement * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score++;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		else if (other.CompareTag("Trap"))
		{
			health--;
			Debug.Log("Health: " + health);
		}
	}
}
