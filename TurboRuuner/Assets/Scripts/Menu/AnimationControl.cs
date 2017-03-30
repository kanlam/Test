using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

	public Animator anim;

	public EnterConfirmWorld enterconfirmfireworld;
	public EnterConfirmWorld enterconfirmoceanworld;

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();

		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

		if(Input.GetButtonDown("Jump")){
			anim.SetTrigger ("isJumping");
		}
		if (moveDirection.z > 0) {
			anim.SetBool ("isRunning", true);	
		} else {
			anim.SetBool ("isRunning", false);
		}
		if (moveDirection.z < 0) {
			anim.SetBool ("isBack", true);
		} else {
			anim.SetBool ("isBack", false);
		 }
		if (moveDirection.x > 0) {
			anim.SetBool ("isRight", true);
		} else {
			anim.SetBool ("isRight", false);
		}
		if (moveDirection.x < 0) {
			anim.SetBool ("isLeft", true);
		} else {
			anim.SetBool ("isLeft", false);
		}

	}



	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.name == "FireWorld") {
			EnterFireWorld ();
		}
		if (hit.gameObject.name == "OceanWorld") {
			EnterOceanWorld ();
		}
	}
	public void EnterFireWorld(){
		enterconfirmfireworld.ToggleMenuFire();
	}
	public void EnterOceanWorld(){
		enterconfirmoceanworld.ToggleMenuOcean();
	}

}
