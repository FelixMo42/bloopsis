using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tileType {empty , floor};

public class tile {
	public tileType type {
		get {
			return type;
		}
		set {
			type = value;
			TypeChangedCB(this);
		}
	}

	public int x;
	public int y;

	map ship;
	installation installed;
	Action<tile> TypeChangedCB;

	public tile(map ship, int x, int y, tileType type = tileType.floor) {
		this.type = type;
		this.ship = ship;
		this.x = x;
		this.y = y;
	}

	public void addTypeChangedCB(Action<tile> func) {
		TypeChangedCB += func;
	}

	public void removeTypeChangedCB(Action<tile> func) {
		TypeChangedCB -= func;
	}
}