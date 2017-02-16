using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {

	bool locked;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update () {
		//get mouse over
		if (!Input.GetMouseButton(keys.pull) || global.mouseOver == null) {
			Ray ray = Camera.main.ScreenPointToRay ( new Vector2(Screen.width / 2, Screen.height / 2) );
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo)) {
				GameObject curr = hitInfo.transform.gameObject;
				while (curr.GetComponent<object_clickable> () == null) {
					curr = curr.transform.parent.gameObject;
				}
				global.mouseOver = curr;
			} else {
				global.mouseOver = null;
			}
		}
		//set cursor mode
		if (Input.GetKeyDown (keys.escape)) {
			locked = !locked;
			if (locked) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}
}