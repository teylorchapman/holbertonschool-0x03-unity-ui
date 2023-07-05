using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 2f;
	private int score = 0;
	public int health = 5;
	public Text scoreText, healthText, winLoseText;
	public Image winLoseBG;

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
			SetScoreText();
			Destroy(other.gameObject);
		}
		else if (other.CompareTag("Trap"))
		{
			health--;
			SetHeatlhText();

			if (health <= 0)
			{
				GameOver();
			}
		}
		else if (other.CompareTag("Goal"))
		{
			///winLoseBG.SetActive(true);
			winLoseText.text = "You Win!";
			winLoseText.color = Color.black;
			winLoseBG.color = Color.green;
			StartCoroutine(LoadScene(3));
		}
	}

	private void GameOver()
	{
		///winLoseBG.SetActive(true);
		winLoseText.text = "Game Over!";
		winLoseText.color = Color.white;
		winLoseBG.color = Color.red;
		
		score = 0;
		health = 5;
		SetScoreText();
		SetHeatlhText();
		StartCoroutine(LoadScene(3));
	}

	public void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}

	public void SetHeatlhText()
	{
		healthText.text = "Health: " + health.ToString();
	}

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
