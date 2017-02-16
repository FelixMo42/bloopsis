using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map {
	tile[,] tiles;

	public int width;

	public int height;

	public map(int width = 100, int height = 100) {
		this.width = width;
		this.height = height;

		tiles = new tile[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [x, y] = new tile (this,x,y);
			}
		}
	}

	public tile getTile (int x, int y) { 
		return tiles [x, y];
	}
}