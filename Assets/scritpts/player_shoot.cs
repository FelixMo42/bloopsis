using UnityEngine;
using System.Collections;

public class player_shoot : MonoBehaviour {

	public Transform gunSpot;
	public float gunPower = 20;

	void Update () {
		if (GlobalVar.mouseOver && GlobalVar.mouseOver.GetComponent<object_moveable>() != null) {
			Vector3 amu = GlobalVar.mouseOver.transform.position - gunSpot.position;
			amu = amu.normalized * gunPower;
			if (Input.GetMouseButton (0)) {
				GlobalVar.mouseOver.transform.position = Vector3.MoveTowards(GlobalVar.mouseOver.transform.position, gunSpot.position, gunPower * Time.deltaTime);
			}
			if (Input.GetMouseButton (1)) {
				GlobalVar.mouseOver.GetComponent<object_moveable>().push(amu);
			}
		}
	}
}