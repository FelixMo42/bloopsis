using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tileType {empty , floor};

public class tile {
	map ship;
	int x;
	int y;
	tileType type;
	installation installed;

	public tile(map ship, int x, int y, tileType type = tileType.empty) {
		this.type = type;
		this.ship = ship;
		this.x = x;
		this.y = y;
	}
}