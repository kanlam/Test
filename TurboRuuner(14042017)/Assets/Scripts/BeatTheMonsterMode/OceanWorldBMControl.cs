using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanWorldBMControl : MonoBehaviour {

	public Animator anim;
	public CharacterController controller;
	public GameObject PlayerCharacter;

	public AudioSource SprintingSound;
	public AudioSource SwimmingSound;
	public AudioSource RunningSound;

	public float speed = 6;
	public float sprintSpeed;
	public float currentSpeed; 
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float turnspeed = 10.0f;
	public bool OnGround = true;
	public bool DoubleJumped;
	public bool isSprinting = false;
	//public bool isBootsed = false;
	public bool isSwimming = false;
	public bool PressingSprint;

	public Slider staminaBar;
	public int maxStamina;
	private int staminaFallrate;//how fast it fall
	public int staminaFallMult;
	private int staminaRegainrate;// how fast it recover
	public int staminaReganinMult;

	private double boostTime = 20f;
	private float boostedSpeed;
	public float boostTimeFallrate = 1f;

	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {

		currentSpeed = speed;
		sprintSpeed = speed * 2;

		staminaBar.maxValue = maxStamina;
		staminaBar.value = maxStamina;
		staminaFallrate = 1;
		staminaRegainrate = 1;
	}

	// Update is called once per frame
	void Update () {
    	AnimationControl();
		AirTime ();
		MovementControl ();
		Sprinting ();


	}

	void MovementControl()
    {

		 moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * speed, moveDirection.y, Input.GetAxis ("Vertical") * currentSpeed);
	     moveDirection = transform.TransformDirection (moveDirection);

		if (OnGround && Input.GetButtonDown ("Jump")) {
		    moveDirection.y = jumpSpeed;
		}

		if (!OnGround && Input.GetButtonDown ("Jump") && !DoubleJumped) {
			moveDirection.y = jumpSpeed;
			DoubleJumped = true;
		}

		moveDirection.y -= gravity*Time.deltaTime;		
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
		if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("isRunning", true);
		} 
		else {
			anim.SetBool ("isRunning", false);
			RunningSound.Play ();

		}
		if (staminaBar.value > 0 && isSprinting) { // ||isbooted
			anim.SetBool ("isSprinting", true);
		} 
		else {
			anim.SetBool ("isSprinting", false);
			SprintingSound.Play ();
		}
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("isBack", true);	
		} 
		else {
			anim.SetBool ("isBack", false);
		}
		if (isSwimming) {
			anim.SetBool ("isSwimming", true);
		} else {
			anim.SetBool ("isSwimming", false);
			SwimmingSound.Play ();
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

	void Sprinting(){

		if (OnGround) {
			if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.P) && !isSwimming) {
				isSprinting = true;
			} else {
				isSprinting = false;
			}
		}

			if (staminaBar.value >= maxStamina) {
				staminaBar.value = maxStamina;

			} else if (staminaBar.value <= 0) {
				isSprinting = false;
				staminaBar.value = 0;
				currentSpeed = speed;
			}

			if (!isSprinting) {
				currentSpeed = speed;
				staminaBar.value += Time.deltaTime / staminaRegainrate * staminaReganinMult;
			}

		    if (isSprinting && PressingSprint) {
				currentSpeed = sprintSpeed;
				staminaBar.value -= Time.deltaTime / staminaFallrate * staminaFallMult;
			}
		 if (isSprinting && !PressingSprint && !OnGround) {
			   currentSpeed = sprintSpeed;
			   staminaBar.value += Time.deltaTime / staminaFallrate * staminaFallMult;
		}

		if (Input.GetKey (KeyCode.P)) {
			PressingSprint = true;
		} else {
			PressingSprint = false;
		}
			/*if (isSprinting && isBootsed ) {
			currentSpeed = sprintSpeed;
			staminaBar.value -= Time.deltaTime / staminaFallrate * staminaFallMult;
			boostTime -= Time.deltaTime * boostTimeFallrate;
			if (boostTime <= 0) {
				isBootsed = false;
				currentSpeed = speed;
				boostTime = 20f;
			}
		}
		if (!isSprinting && isBootsed) {
			currentSpeed = sprintSpeed;
			staminaBar.value += Time.deltaTime / staminaRegainrate * staminaReganinMult;
			boostTime -= Time.deltaTime * boostTimeFallrate;
			if (boostTime <= 0) {
				isBootsed = false;
				currentSpeed = speed;
				boostTime = 20f;
			}
		}*/

	}




	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "water") {
			isSwimming = true;
			//Debug.Log ("inWater");
		} 
	} 
	void OnTriggerExit(){
		isSwimming = false;
	}
}
