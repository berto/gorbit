using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	// boardSizes s,m,l,xl. Defaults to small
	public string boardSize;
	public GameObject[] asteroids;
	public GameObject background;
	private Board board;
	private List <Vector3> gridPositions = new List <Vector3> ();
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

	void BoardSetup (int level) {		
		board = new Board (boardSize);
		Instantiate (background);
		boardX = background.GetComponent<Renderer> ().bounds.size.x;
		boardY = background.GetComponent<Renderer> ().bounds.size.y;
		gridX = boardX / board.columns;
		gridY = boardY / board.rows;
	}

	void DrawBoard () {
		for (int x = 0; x < board.columns; x++) {
			for (int y = 0; y < board.rows; y++) {
				GameObject asteroid = asteroids[Random.Range (0,4)];
				asteroid.transform.localScale = new Vector3 (1, 1, 0f);
				float asteroidSizeX = asteroid.GetComponent<Renderer> ().bounds.size.x;
				float asteroidSizeY = asteroid.GetComponent<Renderer> ().bounds.size.y;
				asteroid.transform.localScale = new Vector3 (gridX/asteroidSizeX, gridY/asteroidSizeY, 0f);
				float positionY = y * gridY - (boardY/2) + gridY/2;
				float positionX = x * gridX - (boardX/2) + gridX/2;
				Vector3 position = new Vector3 (positionX, positionY, 0f);
				Instantiate (asteroid, position, Quaternion.identity);
			}
		}
	}

	public void SetupScene (int level) {
		BoardSetup (level);
		DrawBoard ();
	}
}
