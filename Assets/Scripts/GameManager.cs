using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

	//Static instance of GameManager which allows it to be accessed by any other script.
	public static GameManager instance = null;
	private Text levelText;
	public BoardManager boardscript;
	public int level = 0;

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
		levelText.text = "Level: " + level.ToString();
		boardscript.SetupScene (level);
	}

	public void nextLevel() {
		level++;
		levelText.text = "Level: " + level.ToString();
//		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		GameManager.instance.InitGame ();
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey && e.keyCode == UnityEngine.KeyCode.R)
			boardscript.Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
