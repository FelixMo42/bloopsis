using UnityEngine;
using System.Collections;

public class object_moveable : MonoBehaviour {

	public float gravity = -1;

	Vector3 momentum = Vector3.zero;
	CharacterController controller;
	Vector3 move;
	bool isGrounded;

	public void push (Vector3 push) {
		momentum += push;
	}

	public void pull (Vector3 pull) {
		momentum -= pull;
	}

	void Start () {
		controller = GetComponent<CharacterController> ();
		if (gravity < 0) {
			gravity = global.gravity;
		}
	}

	void OnCollisionStay (Collision collisionInfo) {
		isGrounded = true;
	}

	void OnCollisionExit (Collision collisionInfo) {
		isGrounded = false;
	}
		
	void Update () {
		//gravity
		move = transform.TransformDirection(move);
		if (isGrounded) {
			momentum.y = Mathf.Max(0,momentum.y);
			Debug.Log ("grounded");
		} else {
			if (Input.GetMouseButton (keys.pull) && gameObject == global.mouseOver) {
				momentum.y = Mathf.Lerp(momentum.y,0,Time.deltaTime);
				Debug.Log ("OGS");
			} else {
				momentum.y = Mathf.Lerp(momentum.y,-(int)gravity,Time.deltaTime);
			}
		}
		//momentum
		if (momentum != Vector3.zero) {
			controller.Move(momentum * Time.deltaTime);
			momentum = Vector3.Lerp(momentum, Vector3.zero, 5 * Time.deltaTime);
		}
	}
}