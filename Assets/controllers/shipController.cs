using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour {
	map ship;

	public int width = 10;
	public int height = 10;
	public int tileSize = 1;

	void creatTileObject(tile tile_data) {
		//main
		GameObject tile_go = new GameObject("tile " + tile_data.x + " " + tile_data.y);
		tile_go.transform.localPosition = new Vector3 (tile_data.x * tileSize, 0,  tile_data.y * tileSize);
		//mesh
		GameObject tile_mesh = GameObject.CreatePrimitive (PrimitiveType.Plane);
		tile_mesh.transform.localScale = new Vector3 (tileSize / 10f , 1 , tileSize / 10f );
		tile_mesh.transform.parent = tile_go.transform;
		tile_mesh.transform.localPosition = Vector3.zero;
		tile_mesh.name = "mesh";
		if (tile_data.type == tileType.empty) {
			tile_mesh.SetActive (false);
		}
	}

	void onTileTypeChange(tile tile_data, GameObject tile_mesh) {
		if (tile_data.type == tileType.floor) {
			tile_mesh.SetActive (true);
		} else {
			tile_mesh.SetActive (false);
		}
	}

	void Start () {
		ship = new map(width,height);
		for (int x = 0; x < ship.width; x++) {
			for (int y = 0; y < ship.height; y++) {
				creatTileObject (ship.getTile (x, y));
			}
		}
	}
}