using UnityEngine;
using System.Collections;

public class player_shoot : MonoBehaviour {

	public Transform gunSpot;
	public float gunPullPower = 20;
	public float gunPushPower = 5;

	void Update () {
		if (global.mouseOver && global.mouseOver.GetComponent<object_moveable>() != null) {
			if (Input.GetMouseButton (keys.pull)) {
				global.mouseOver.transform.position = Vector3.MoveTowards(global.mouseOver.transform.position, gunSpot.position, gunPullPower * Time.deltaTime);
			}
			if (Input.GetMouseButton (keys.push)) {
				Vector3 amu = global.mouseOver.transform.position - gunSpot.position;
				amu = amu.normalized * gunPushPower;
				global.mouseOver.GetComponent<object_moveable>().push(amu);
			}
		}
	}
}