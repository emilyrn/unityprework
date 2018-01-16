using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text gameOverText;
	public Text winText;
	public float totaltime = 0;

	private bool gameOver;
	private int score;
	private bool winner;

	void Start ()
	{
		gameOver = false;
		winner = false;
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		winText.text = "";
	}
		
	IEnumerator SpawnWaves () 
	{	
		yield return new WaitForSeconds (startWait);
		while (true)
		{

			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				break;
			}

			if (winner) {
				break;

			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;

		if (score == 100) {
			winner = true;
			Winner ();
		}
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over :(";
		gameOver = true;
	}
	public void Winner ()
	{
		winText.text = "You Win :D";
	}
}
