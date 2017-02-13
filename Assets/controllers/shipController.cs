using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour {
	map ship;

	public int tileWidth = 1;
	public int tileHeight = 1;

	void start () {
		ship = new map();
	}
}