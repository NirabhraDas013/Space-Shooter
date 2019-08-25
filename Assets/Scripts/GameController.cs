using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public GameObject Restart;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text waveText;
	public Text scoreText;
	public Text gameOverText;
	public Button restartButton;

	private bool gameOver;
	private int score;

	// Use this for initialization
	void Start ()
	{
		gameOver = false;
		gameOverText.text = "";
		waveText.text = "";
		Restart.SetActive (false);
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			waveText.text = "";
			for (int i = 0; i <= hazardCount; i++)
			{
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
			waveText.text = "!!Prepare For The Next Wave!!";

			if (gameOver)
			{
				Restart.SetActive (true);
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score.ToString ();
	}

	public void GameOver ()
	{
		gameOver = true;
		gameOverText.text = "!GAME OVER!";
	}



}
