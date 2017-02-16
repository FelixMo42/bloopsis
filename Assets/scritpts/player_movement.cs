using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {
	public float speed = 8.0F;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0f;

	public float horizontalScroll = 5;
	public float verticalScroll = 5;

	Animator anim;
	CharacterController player;
	Camera cam;
	Vector3 move;

	bool AnimatorIsPlaying(){
		return anim.GetCurrentAnimatorStateInfo(0).length > anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}

	bool playing(string name) {
		anim.Update (0f);
		return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(name);;
	}
		
	void Start () {
		player = GetComponent<CharacterController>();
		cam = player.GetComponentInChildren<Camera>();
		if (GetComponent<object_moveable> () != null) {
			GetComponent<object_moveable> ().gravity = 0;
		}
		anim = GetComponentsInChildren<Animator> ()[0];
	}

	void OnCollisionStay (Collision collisionInfo) {
		anim.SetBool ("grounded",true);
	}

	void OnCollisionExit (Collision collisionInfo) {
		anim.SetBool ("grounded",false);
	}

	void Update () {
		//move
		move.x = Input.GetAxis("Horizontal") * speed;
		move.z = Input.GetAxis("Vertical") * speed;
		move = transform.TransformDirection(move);

		int s = (int)Mathf.Abs (move.x) + (int)Mathf.Abs (move.z);
		anim.SetInteger ("speed", s );
		if (s > 0 && player.isGrounded && !playing("Walking") ) {
			anim.Play ("Walking");
		} else if (s == 0 && player.isGrounded) {
			anim.Play ("Idle");
		}

		if (Input.GetKeyDown(keys.jump) && player.isGrounded) {
			move.y = jumpSpeed;
			anim.Play("Jumping");
		}
		move.y -= gravity * Time.deltaTime;
		player.Move(move * Time.deltaTime);
		//rotate player and camera
		float rx = horizontalScroll * Input.GetAxis("Mouse X");
		float ry = verticalScroll * Input.GetAxis("Mouse Y");
		transform.Rotate(0, rx, 0, Space.Self);
		cam.transform.Rotate(-ry, 0, 0, Space.Self);
	}
}