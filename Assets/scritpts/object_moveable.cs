using UnityEngine;
using System.Collections;

public class object_moveable : MonoBehaviour {

	public float gravity = -1;

	Vector3 momentum = Vector3.zero;
	CharacterController controller;
	Vector3 move;

	public void push (Vector3 push) {
		momentum += push;
	}

	public void pull (Vector3 push) {
		momentum -= push;
	}

	void Start () {
		controller = GetComponent<CharacterController> ();
		if (gravity < 0) {
			gravity = GlobalVar.gravity;
		}
	}
		
	void Update () {
		//gravity
		move = transform.TransformDirection(move);
		if (controller.isGrounded) {
			momentum.y = 0;
		} else {
			momentum.y -= gravity * Time.deltaTime;
		}
		//momentum
		if (momentum != Vector3.zero) {
			controller.Move(momentum * Time.deltaTime);
			momentum = Vector3.Lerp(momentum, Vector3.zero, 5 * Time.deltaTime);
		}
	}
}