using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

	//Static instance of GameManager which allows it to be accessed by any other script.
	public static GameManager instance = null;
	private Text levelText;
	private Text restartText;
	private Text winText;
	private Text resetText;
	public BoardManager boardscript;
	public int level = 0;
	private float maxX = 100;
	private float maxY = 100;
	private bool gameOver = false;

	void Awake () {
		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		boardscript = GetComponent<BoardManager> ();
		InitGame ();
	}
		
	//This is called each time a scene is loaded.
	static private void OnSceneLoaded() {
    	instance.level++;
		instance.InitGame ();
	}

	void InitGame() {
		levelText = GameObject.Find("LevelText").GetComponent<Text>();
		restartText = GameObject.Find("RestartText").GetComponent<Text>();
		winText = GameObject.Find("WinText").GetComponent<Text>();
		resetText = GameObject.Find("ResetText").GetComponent<Text>();
		levelText.text = "Level: " + level.ToString();
		hideText ();
		boardscript.SetupScene (level);
	}

	void hideText() {
		restartText.enabled = false;
		resetText.enabled = false;
		winText.enabled = false;
	}

	void displayGameOverText() {
		resetText.enabled = true;
		winText.enabled = true;
	}

	void Update () {
		float vertExtent = Camera.main.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			displayRestartText (players [i].transform.position.x, players [i].transform.position.y, horzExtent, vertExtent);
			limitPlayer (players[i], players [i].transform.position.x, players [i].transform.position.y);
		}
	}

	public void NextLevel() {
		instance.level++;
		instance.levelText.text = "Level: " + level.ToString();
		instance.InitGame ();
	}

	public void PreviousLevel() {
		instance.level--;
		instance.levelText.text = "Level: " + level.ToString();
		instance.InitGame ();
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey && e.keyCode == UnityEngine.KeyCode.R)
			Reset ();
		else if (e.isKey && e.keyCode == UnityEngine.KeyCode.M && e.type == EventType.KeyUp)
			ToggleMusic ();
		else if (e.isKey && e.keyCode == UnityEngine.KeyCode.Space && e.type == EventType.KeyUp && gameOver)
			RestartGame ();
	}

	public void Reset() {
		boardscript.Reset ();
	}

	public void RestartGame() {
		gameOver = false;
		instance.level = 0;
		SoundManager.instance.PlayMusic ();
		instance.levelText.enabled = true;
		instance.InitGame ();
	}

	public void EndGame() {
		gameOver = true;
		displayGameOverText ();
		SoundManager.instance.PlayEnding ();
		boardscript.DisplayWinScreen ();
	}

	public void ToggleMusic() {
		if (SoundManager.instance.musicSource.isPlaying) {
			SoundManager.instance.musicSource.Pause ();
			SoundManager.instance.efxSource.mute = true;
		} else {
			SoundManager.instance.musicSource.Play ();
			SoundManager.instance.efxSource.mute = false;
		}
	}

	void displayRestartText(float playerX, float playerY, float cameraX, float cameraY) {
		if (playerX < -cameraX || playerX > cameraX) {
			restartText.enabled = true;
		} else if (playerY < -cameraY || playerY > cameraY) {
			restartText.enabled = true;
		} else {
			restartText.enabled = false;
		}
	}

	void limitPlayer(GameObject player, float playerX, float playerY) {
		if (playerX < -maxX) {
			player.transform.position = new Vector3 (-maxX, player.transform.position.y, 0f);
		} else if (playerX > maxX) {
			player.transform.position = new Vector3 (maxX, player.transform.position.y, 0f);
		} else if (playerY > maxY) {
			player.transform.position = new Vector3 (player.transform.position.y, maxY, 0f);
		} else if (playerY < -maxY) {
			player.transform.position = new Vector3 (player.transform.position.y, -maxY, 0f);
		}
	}

}
