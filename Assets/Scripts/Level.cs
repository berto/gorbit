using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {

	private string size;
	private int[][] grid;
	private string[] sizes;
	private int[][][] levels = new int[1][][];

	public Level (int level) {
		initializeLevels ();
		sizes = new string[] { "s" };
		grid = levels [level];
		size = sizes [level];
	}

	public string getSize() {
		return size;
	}

	public int[][] getGrid() {
		return grid;
	}

	private void initializeLevels() {
		// Level 0
		int[][] level_0 = new int[4][];
		level_0[0] = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
		level_0[1] = new int[]{ 0, 0, 0, 0, 2, 0, 0 };
		level_0[2] = new int[]{ 0, 1, 0, 0, 0, 0, 0 };
		level_0[3] = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
		levels.SetValue (level_0, 0);
	}
}
