using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
    public float speed = 8.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0f;

    public float horizontalScroll = 5;
    public float verticalScroll = 5;

    CharacterController player;
    Camera cam;
    Vector3 move;

    void Start () {
        player = GetComponent<CharacterController>();
        cam = player.GetComponentInChildren<Camera>();
		if (GetComponent<object_moveable> () != null) {
			GetComponent<object_moveable> ().gravity = 0;
		}
    }
	
	void Update () {
        //move
        move.x = Input.GetAxis("Horizontal") * speed;
        move.z = Input.GetAxis("Vertical") * speed;
        move = transform.TransformDirection(move);
        if (Input.GetButton("Jump") && player.isGrounded) {
            move.y = jumpSpeed;
        }
        move.y -= gravity * Time.deltaTime;
        player.Move(move * Time.deltaTime);
        //rotate player and camera
        float mx = horizontalScroll * Input.GetAxis("Mouse X");
        float my = verticalScroll * Input.GetAxis("Mouse Y");
        transform.Rotate(0, mx, 0, Space.Self);
        cam.transform.Rotate(-my, 0, 0, Space.Self);
    }
}