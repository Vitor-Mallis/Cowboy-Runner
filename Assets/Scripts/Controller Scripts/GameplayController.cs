using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	Button resumeButton;

	[SerializeField]
	Text pauseText, scoreText;

	[SerializeField]
	GameObject pausePanel, pauseButton;

	int score;

	void Start() {
		PlayerDeath.isDead += PlayerDied;
		StartCoroutine ("AddScore");
	}

	IEnumerator AddScore() {
		yield return new WaitForSeconds (1f);
		if (Time.timeScale != 0) {
			score++; 
			SetScore (score);
		}
		StartCoroutine(AddScore());
	}

	public void SetScore(int score) {
		scoreText.text = score + " m";
	}

	public void PlayerDied() {
		PlayerDeath.isDead -= PlayerDied;
		Time.timeScale = 0f;
		pauseText.text = "Game Over";
		pauseButton.SetActive (false);
		pausePanel.SetActive (true);

		if (!PlayerPrefs.HasKey ("Highscore"))
			PlayerPrefs.SetInt ("Highscore", 0);

		if(score > PlayerPrefs.GetInt("Highscore"))
			PlayerPrefs.SetInt("Highscore", score);

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => Restart ());
	}

	public void Pause() {
		Time.timeScale = 0f;
		pauseButton.SetActive (false);
		pausePanel.SetActive (true);

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => Resume ());
	}

	public void Resume() {
		Time.timeScale = 1f;
		pauseButton.SetActive (true);
		pausePanel.SetActive (false);
	}

	public void Restart() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Gameplay");
	}

	public void MainMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
}
