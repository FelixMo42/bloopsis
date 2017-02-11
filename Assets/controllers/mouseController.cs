using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {
	
	public GameObject selected;

	object_clickable obj;

	object_clickable getClickable(GameObject obj) {
		if (obj.GetComponent<object_clickable>() != null) {
			return obj.GetComponent<object_clickable>();
		}
		return obj.GetComponentInParent<object_clickable>();
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast( ray, out hitInfo) ) {
			if (hitInfo.transform != null) {
				selected = hitInfo.transform.gameObject;
				obj = getClickable (selected);
			}
		} else {
			selected = null;
		}
	}
}