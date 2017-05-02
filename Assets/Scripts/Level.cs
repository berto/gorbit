using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {

	private int level;
	private string size;
	private int[][] grid;
	private string[] sizes;
	private int[][][] levels;

	public Level (int _level) {
		level = _level;
		sizes = initializeLevels (); 
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

	private string[] initializeLevels() {
		// Define number of levels
		levels = new int[7][][];

		int[][] level_0 = generateLevel0();
		int[][] level_1 = generateLevel1();
		int[][] level_2 = generateLevel2();
		int[][] level_3 = generateLevel3();
		int[][] level_4 = generateLevel4();
		int[][] level_5 = generateLevel5();
		int[][] level_6 = generateLevel6();

		levels.SetValue (level_0, 0);
		levels.SetValue (level_1, 1);
		levels.SetValue (level_2, 2);
		levels.SetValue (level_3, 3);
		levels.SetValue (level_4, 4);
		levels.SetValue (level_5, 5);
		levels.SetValue (level_6, 6);

		// Define sizes
		return new string[] { "s", "m", "m", "m", "m", "l", "s" };
	}

	private int[][] generateLevel0() {
		int[][] level = new int[4][];
		level[0] = new int[]{ 0, 0, 0, 0, 0 };
		level[1] = new int[]{ 0, 1, 0, 0, 0 };
		level[2] = new int[]{ 0, 0, 0, 2, 0 };
		level[3] = new int[]{ 0, 0, 0, 0, 0 };
		return level;
	}

	private int[][] generateLevel1() {
		int[][] level = new int[8][];
		level[0] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
		level[1] = new int[]{ 0, 3, 0, 0, 0, 0, 0, 0, 0, 0 };
		level[2] = new int[]{ 0, 0, 0, 0, 0, 0, 3, 0, 0, 0 };
		level[3] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[4] = new int[]{ 0, 1, 0, 0, 0, 0, 3, 0, 2, 0 };
		level[5] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level[6] = new int[]{ 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
		level[7] = new int[]{ 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 };
		return level;
	}

	private int[][] generateLevel2() {
		int[][] level = new int[8][];
		level[0] = new int[]{ 0, 3, 0, 0, 3, 0, 3, 0, 0, 0 };
		level[1] = new int[]{ 0, 0, 0, 3, 0, 0, 3, 0, 1, 0 };
		level[2] = new int[]{ 0, 0, 2, 0, 3, 0, 0, 0, 0, 0 };
		level[3] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 0, 3, 0 };
		level[4] = new int[]{ 3, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[5] = new int[]{ 0, 0, 0, 0, 0, 0, 3, 0, 0, 3 };
		level[6] = new int[]{ 3, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
		level[7] = new int[]{ 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 };
		return level;
	}

	private int[][] generateLevel3() {
		int[][] level = new int[8][];
		level[0] = new int[]{ 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
		level[1] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[2] = new int[]{ 3, 0, 1, 0, 3, 0, 0, 0, 0, 0 };
		level[3] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[4] = new int[]{ 3, 0, 0, 3, 0, 3, 0, 2, 0, 0 };
		level[5] = new int[]{ 0, 0, 3, 0, 0, 0, 3, 0, 0, 3 };
		level[6] = new int[]{ 3, 0, 0, 0, 3, 0, 0, 3, 0, 0 };
		level[7] = new int[]{ 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 };
		return level;
	}

	private int[][] generateLevel4() {
		int[][] level = new int[8][];
		level[0] = new int[]{ 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
		level[1] = new int[]{ 0, 1, 0, 0, 0, 0, 2, 0, 0, 0 };
		level[2] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		level[3] = new int[]{ 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[4] = new int[]{ 0, 0, 0, 3, 0, 3, 0, 0, 3, 0 };
		level[5] = new int[]{ 3, 0, 0, 0, 0, 0, 3, 0, 0, 3 };
		level[6] = new int[]{ 0, 0, 1, 0, 0, 0, 3, 0, 0, 0 };
		level[7] = new int[]{ 0, 3, 0, 0, 0, 0, 0, 0, 0, 0 };
		return level;
	}

	private int[][] generateLevel5() {
		int[][] level = new int[12][];
		level[0] = new int[]{ 3, 3, 0, 0, 3, 3, 0, 0, 3, 0, 3, 0, 0, 0, 0 };
		level[1] = new int[]{ 0, 3, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0 };
		level[2] = new int[]{ 3, 0, 3, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 };
		level[3] = new int[]{ 0, 2, 0, 3, 0, 0, 3, 0, 0, 0, 3, 3, 0, 0, 0 };
		level[4] = new int[]{ 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 1, 0, 3 };
		level[5] = new int[]{ 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[6] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 0 };
		level[7] = new int[]{ 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0 };
		level[8] = new int[]{ 0, 0, 0, 0, 0, 3, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
		level[9] = new int[]{ 0, 3, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 };
		level[10] =new int[]{ 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
		level[11] =new int[]{ 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0 };
		return level;
	}

	private int[][] generateLevel6() {
		int[][] level = new int[4][];
		level[0] = new int[]{ 0, 0, 3, 0, 0 };
		level[1] = new int[]{ 0, 0, 0, 4, 0 };
		level[2] = new int[]{ 0, 1, 0, 0, 0 };
		level[3] = new int[]{ 0, 0, 0, 0, 3 };
		return level;
	}
}
