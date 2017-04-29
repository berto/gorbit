using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {

	private int level;
	private string size;
	private int[][] grid;
	private string[] sizes;
	private int[][][] levels = new int[3][][];

	public Level (int _level) {
		level = _level;
		initializeLevels ();
		sizes = new string[] { "s", "m", "m" };
		grid = levels [level];
		size = sizes [level];
	}

	public string getSize() {
		return size;
	}

	public int[][] getGrid() {
		return grid;
	}

	public int getLevel() {
		return level;
	}

	private void initializeLevels() {
		// Level 0
		int[][] level_0 = new int[4][];
		level_0[0] = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
		level_0[1] = new int[]{ 0, 0, 0, 0, 2, 0, 0 };
		level_0[2] = new int[]{ 0, 1, 0, 0, 0, 0, 0 };
		level_0[3] = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
		levels.SetValue (level_0, 0);
		// Level 1
		int[][] level_1 = new int[8][];
		level_1[0] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0 };
		level_1[1] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level_1[2] = new int[]{ 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 };
		level_1[3] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level_1[4] = new int[]{ 0, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0 };
		level_1[5] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level_1[6] = new int[]{ 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0 };
		level_1[7] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0 };
		levels.SetValue (level_1, 1);
		// Level 2
		int[][] level_2 = new int[8][];
		level_2[0] = new int[]{ 0, 0, 0, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0, 0 };
		level_2[1] = new int[]{ 0, 0, 0, 3, 0, 0, 3, 0, 0, 0, 3, 0, 1, 0 };
		level_2[2] = new int[]{ 0, 3, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level_2[3] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
		level_2[4] = new int[]{ 3, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level_2[5] = new int[]{ 0, 0, 0, 0, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0 };
		level_2[6] = new int[]{ 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level_2[7] = new int[]{ 0, 3, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		levels.SetValue (level_2, 2);
	}
}
