using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayercontrol : MonoBehaviour {

	public Animator anim;

	public EnterConfirmWorld enterOceanWorld;
	public EnterConfirmWorld enterFireWorld;


	public float speed = 10.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float turnspeed = 10.0f;

	private Vector3 moveDirection = Vector3.zero;

	public bool isMenu = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (isMenu) {
			anim.SetBool ("isRunning", false);
			return;
		}

		if (!isMenu) {
			float rotation = Input.GetAxis ("Horizontal") * turnspeed;
			rotation *= Time.deltaTime;
			transform.Rotate (0, rotation, 0);

			CharacterController controller = GetComponent<CharacterController> ();

			if (controller.isGrounded) {
				moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				if (Input.GetButton ("Jump"))
					moveDirection.y = jumpSpeed;
			}

			moveDirection.y -= gravity * Time.deltaTime;

			controller.Move (moveDirection * Time.deltaTime);

			if (Input.GetButtonDown ("Jump")) {
				anim.SetTrigger ("isJumping");
			}
			if (!controller.isGrounded) {
				anim.SetBool ("isAir", false);		
			} else {
				anim.SetBool ("isAir", true);
			}
			if (Input.GetKey (KeyCode.W)) {
				anim.SetBool ("isRunning", true);	
			} else {
				anim.SetBool ("isRunning", false);
			}
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.SetBool ("isSprinting", true);
			} else {
				anim.SetBool ("isSprinting", false);
			}
			if (Input.GetKey (KeyCode.S)) {
				anim.SetBool ("isBack", true);	
			} else {
				anim.SetBool ("isBack", false);
			}
		}
	}	

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.name == "OceanWorld") {
			enterOceanWorld.ToggleMenuOcean();
			isMenu = true;
		}
		if (hit.gameObject.name == "FireWorld") {
			enterFireWorld.ToggleMenuFire();
			isMenu = true;
		}
	}
}
