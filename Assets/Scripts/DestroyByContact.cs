using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explotion;
	public GameObject playerExplotion;
	public int scoreValue;
	private GameController gamecontroller;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gamecontroller = gameControllerObject.GetComponent<GameController> ();
		}
		if(gamecontroller == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explotion != null)
		{
			Instantiate (explotion, transform.position, transform.rotation);
		}
		if (other.tag == "Player") 
		{
			Instantiate (playerExplotion, other.transform.position, other.transform.rotation);
			gamecontroller.GameOver ();
		}

		gamecontroller.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
