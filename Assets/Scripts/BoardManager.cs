using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	// boardSizes s,m,l,xl. Defaults to small
	public GameObject[] asteroids;
	public GameObject background;
	public GameObject player;
	public GameObject princess;
	public GameObject pickup;
	public GameObject winBanner;
	private GameObject backgroundInstance;
	private Level currentLevel;
	private Board board;
	private float gridX;
	private float gridY;
	private float boardX;
	private float boardY;
	private List<GameObject> items = new List<GameObject>();
	private List<GameObject> players = new List<GameObject>();
	private List<Vector3> playerPositions = new List<Vector3>();
	private bool showMusicHint = true;

	private class Board {
		public int columns = 7;
		public int rows = 4;
		private string[] sizes = new string[4] {"s", "m", "l", "xl"};

		public Board (string size) {
			for (int i = 1; i < sizes.Length + 1; i++) {
				if (sizes[i-1] == size) {
					columns *= i;
					rows *= i;
				}
			}
		}
	}

	void BoardSetup (string size) {
		if (backgroundInstance == null) {
			backgroundInstance = Instantiate (background);
		}
		board = new Board (size);
		boardX = background.GetComponent<Renderer> ().bounds.size.x;
		boardY = background.GetComponent<Renderer> ().bounds.size.y;
		gridX = boardX / board.columns;
		gridY = boardY / board.rows;
	}

	private void DrawBoard (int[][] grid) {
		for (int x = 0; x < board.columns; x++) {
			for (int y = 0; y < board.rows; y++) {
				int item = grid [board.rows - y - 1] [x];
				if (item != 0) {
					GameObject toInstantiate = selectGameObject (item);
					float itemSizeX = toInstantiate.GetComponent<Renderer> ().bounds.size.x;
					float itemSizeY = toInstantiate.GetComponent<Renderer> ().bounds.size.y;
					toInstantiate.transform.localScale = new Vector3 (gridX / itemSizeX, gridY / itemSizeY, 0f);
					float positionY = y * gridY - (boardY / 2) + gridY / 2;
					float positionX = x * gridX - (boardX / 2) + gridX / 2;
					Vector3 position = new Vector3 (positionX, positionY, 0f);
					GameObject newItem = Instantiate (toInstantiate, position, Quaternion.identity);
					if (newItem.tag == "Player") {
						players.Add (newItem);
						playerPositions.Add (position);
					} else {
						items.Add (newItem);
					}
				}
			}
		}
	}

	private GameObject selectGameObject(int item) {
		float defaultX = 1;
		float defaultY = 1;
		GameObject toInstantiate = asteroids [Random.Range (0, 4)];
		if (item == 1) {
			toInstantiate = player;
			defaultX = 1.2f;
			defaultY = 1.2f;
		} else if (item == 2) {
			toInstantiate = pickup;
			defaultX = 2;
			defaultY = 2;
		} else if (item == 4) {
			toInstantiate = princess;
			defaultX = 1.4f;
			defaultY = 1.2f;
		}
		toInstantiate.transform.localScale = new Vector3 (defaultX, defaultY, 0f);
		return toInstantiate;
	}

	void clearBoard() {
		for (int i = 0; i < items.Count; i++) {
			Destroy(items[i]);
		}
		for (int i = 0; i < players.Count; i++) {
			Destroy(players[i]);
		}
		players = new List<GameObject> ();
		playerPositions = new List<Vector3> ();
		items = new List<GameObject>();
	}

	public void DisplayWinScreen() {
		clearBoard ();
		GameObject.Find ("LevelText").GetComponent<Text> ().enabled = false;
		items.Add (Instantiate (winBanner, new Vector3 (0, 0, 0f), Quaternion.identity));
	}

	public void Reset() {
		redrawPlayers ();
	}

	void redrawPlayers() {
		for (int i = 0; i < players.Count; i++) {
			Destroy(players[i]);
		}
		players = new List<GameObject>();
		for (int i = 0; i < playerPositions.Count; i++) {
			players.Add(Instantiate (player, playerPositions[i], Quaternion.identity));
		}
	}

	public void SetupScene (int level) {
		if (items.Count > 0) {
			clearBoard ();
		}
		currentLevel = new Level(level);
		BoardSetup (currentLevel.getSize());
		DrawBoard (currentLevel.getGrid());
		if (currentLevel.getLevel () > 0 && showMusicHint) {
			GameObject.Find("MusicText").GetComponent<Text>().enabled = false;
		}
	}
}
