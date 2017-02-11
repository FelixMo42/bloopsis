using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {
	
	public GameObject selected;

	object_clickable clickable;

	void Update () {
		//set mouse over
		if (!Input.GetMouseButton (0) && !Input.GetMouseButton (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo)) {
				GameObject curr = hitInfo.transform.gameObject;
				while (curr.GetComponent<object_clickable> () == null) {
					curr = curr.transform.parent.gameObject;
				}
				selected = curr;
				clickable = curr.GetComponent<object_clickable> ();
				GlobalVar.mouseOver = curr;
			} else {
				selected = null;
				GlobalVar.mouseOver = null;
			}
		}
	}
}