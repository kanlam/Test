using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanWorldBMControl : MonoBehaviour {

	public Animator anim;
	public CharacterController controller;
	public GameObject PlayerCharacter;

	public DeadMenu deathMenu;
	public WinMenu winMenu;

	public float speed = 6;
	public float sprintSpeed;
	public float currentSpeed; 
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float turnspeed = 10.0f;
	public bool OnGround;
	public bool DoubleJumped;
	public bool isRunning;
	public bool isSprinting;
	public bool isDead;
	public bool isWin;
	//public bool isBootsed = false;
	public bool isSwimming;
	public bool PressingSprint;

	public Slider staminaBar;
	public int maxStamina;
	private int staminaFallrate;//how fast it fall
	public int staminaFallMult;
	private int staminaRegainrate;// how fast it recover
	public int staminaReganinMult;

	public AudioSource source;

	public AudioClip Jump;
	public AudioClip DJump;


	/*private double boostTime = 20f;
	private float boostedSpeed;
	public float boostTimeFallrate = 1f;*/

	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Awake () {

		source = GetComponent<AudioSource> ();

		currentSpeed = speed;
		sprintSpeed = speed * 2;

		staminaBar.maxValue = maxStamina;
		staminaBar.value = maxStamina;
		staminaFallrate = 1;
		staminaRegainrate = 1;
	}

	// Update is called once per frame
	void Update () {

		if (isDead) {
			AnimationControl ();
			StartCoroutine ("Wait");
			return;
		}
		if (isWin) {
			AnimationControl ();
			StartCoroutine ("Wait");
			return;
		}
		if (!isDead) {
			AnimationControl ();
			AirTime ();
			MovementControl ();
			Sprinting ();
		}
	}

	void MovementControl()
	{
		 moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * speed, moveDirection.y, Input.GetAxis ("Vertical") * currentSpeed);
	     moveDirection = transform.TransformDirection (moveDirection);

		if (OnGround && Input.GetButtonDown ("Jump")) {
		    moveDirection.y = jumpSpeed;
			source.clip = Jump;
			source.Play ();
		}

		if (!OnGround && Input.GetButtonDown ("Jump") && !DoubleJumped) {
			moveDirection.y = jumpSpeed;
			DoubleJumped = true;
			source.clip = DJump;
			source.Play ();
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
		}
		if (staminaBar.value > 0 && isSprinting) { // ||isbooted
			anim.SetBool ("isSprinting", true);
		} 
		else {
			anim.SetBool ("isSprinting", false);
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
		}
		if (isDead) {
			anim.SetBool ("isDead", true);
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

		if (OnGround && !isSwimming && Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.W)) {
			isRunning = true;
		} else {
			isRunning = false;
		}

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

	public void OnDeath()
	{
		deathMenu.ToggleDeathMenu ();
	}

	public void Onwin()
	{
		winMenu.ToggleWinMenu ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "water") {
			isSwimming = true;
		} 
		if (other.gameObject.name == "Monster") {
			isDead = true;

		}
		if (other.gameObject.name == "OceanWorldGoal")
			isWin = true;	    
	} 
	void OnTriggerExit(){
		isSwimming = false;
		//SwimmingSound.Stop();
	}

	IEnumerator Wait(){
		if (isWin) {
			yield return new WaitForSeconds (5);
			Onwin ();
		}
		if (isDead) {
			yield return new WaitForSeconds (5);
			OnDeath ();
		}
	}
}
