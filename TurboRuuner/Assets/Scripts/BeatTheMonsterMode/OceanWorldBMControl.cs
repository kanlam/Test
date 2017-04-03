using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanWorldBMControl : MonoBehaviour {

	public Animator anim;
	public CharacterController controller;

	public float speed = 10.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float turnspeed = 10.0f;
	public bool OnGround = true;
	public bool DoubleJumped;

	private Vector3 moveDirection = Vector3.zero;

	public bool isMenu = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
    	AnimationControl();
		AirTime ();
		MovementControl ();   
	}

	void MovementControl()
	{
		if (controller.isGrounded) {
			float rotation = Input.GetAxis ("Horizontal") * turnspeed;
			rotation *= Time.deltaTime;
			transform.Rotate (0, rotation, 0);

			moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);

			if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.P)) {
				moveDirection *= speed * 2;
			} else {
				moveDirection *= speed;
			}
			if (OnGround && Input.GetButtonDown ("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}      

		if (!OnGround && Input.GetButtonDown ("Jump") && !DoubleJumped) 
		{
			moveDirection.y = jumpSpeed;
			DoubleJumped = true;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	void AnimationControl()
	{
		if (OnGround && Input.GetButtonDown ("Jump")) {
			anim.SetTrigger ("isJumping");
		} 

		if (!OnGround && Input.GetButtonDown ("Jump") && !DoubleJumped) {
			anim.SetTrigger ("DoubleJump");

		}
		if (controller.isGrounded) {
			anim.SetBool ("isAir", false);		
		} 
		else {
			anim.SetBool ("isAir", true);
		}
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("isRunning", true);	
		} 
		else {
			anim.SetBool ("isRunning", false);
		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.P)) {
			anim.SetBool ("isSprinting", true);
		} 
		else {
			anim.SetBool ("isSprinting", false);
		}
		if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("isBack", true);	
		} 
		else {
			anim.SetBool ("isBack", false);
		}
	}

	void AirTime()
	{
		if (!controller.isGrounded) {
			OnGround = false;
		} else {
			OnGround = true;
			DoubleJumped = false;
		}
	}
}
