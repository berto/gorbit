using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	// boardSizes s,m,l,xl. Defaults to small
	public GameObject[] asteroids;
	public GameObject background;
	public GameObject player;
	public GameObject pickup;
	private Level currentLevel;
	private Board board;
	private float gridX;
	private float gridY;
	private float boardX;
	private float boardY;

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
		board = new Board (size);
		Instantiate (background);
		boardX = background.GetComponent<Renderer> ().bounds.size.x;
		boardY = background.GetComponent<Renderer> ().bounds.size.y;
		gridX = boardX / board.columns;
		gridY = boardY / board.rows;
	}

	private void DrawBoard (int[][] grid) {
		for (int x = 0; x < board.columns; x++) {
			for (int y = 0; y < board.rows; y++) {
				int item = grid [y] [x];
				if (item != 0) {
					GameObject toInstantiate = selectGameObject (item);
					float itemSizeX = toInstantiate.GetComponent<Renderer> ().bounds.size.x;
					float itemSizeY = toInstantiate.GetComponent<Renderer> ().bounds.size.y;
					toInstantiate.transform.localScale = new Vector3 (gridX / itemSizeX, gridY / itemSizeY, 0f);
					float positionY = y * gridY - (boardY / 2) + gridY / 2;
					float positionX = x * gridX - (boardX / 2) + gridX / 2;
					Vector3 position = new Vector3 (positionX, positionY, 0f);
					Instantiate (toInstantiate, position, Quaternion.identity);
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
		} else if (item == 2) {
			toInstantiate = pickup;
			defaultX = 2;
			defaultY = 2;
		}
		toInstantiate.transform.localScale = new Vector3 (defaultX, defaultY, 0f);
		return toInstantiate;
	}

	public void SetupScene (int level) {
		currentLevel = new Level(level);
		BoardSetup (currentLevel.getSize());
		DrawBoard (currentLevel.getGrid());
	}
}
