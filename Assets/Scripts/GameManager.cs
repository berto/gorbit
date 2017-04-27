using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

	//Static instance of GameManager which allows it to be accessed by any other script.
	public static GameManager instance = null;              
	public BoardManager boardscript;
	private int level = 0;

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

	void InitGame() {
		boardscript.SetupScene (level);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
