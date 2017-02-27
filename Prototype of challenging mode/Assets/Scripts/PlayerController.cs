using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	private CharacterController controller;
	private Vector3 moveVector;


	public float speed = 6;
	public float currentSpeed;
	public float sprintSpeed;
	public float jumpForce; 
	public bool isSprinting = false;


	public Slider staminaBar;
	public int maxStamina;
	private int staminaFallrate;//how fast it fall
	public int staminaFallMult;
	private int staminaRegainrate;// how fast it recover
	public int staminaReganinMult;

	private float verticalVelocity = 0.0f;
	private float gravity = 14.0f;

	private double boostTime = 20f;
	private float boostedSpeed;
	public bool isBoosted = false;
	public float boostTimeFallrate = 1f;

	//private float currentStamina = 3.0f;

	// Use this for initialization
	void Start () {
		currentSpeed = speed;
		sprintSpeed = speed * 2;
		controller = GetComponent<CharacterController> ();
		staminaBar.maxValue = maxStamina;
		staminaBar.value = maxStamina;

		staminaFallrate = 1;
		staminaRegainrate = 1;
	}
	
	// Update is called once per frame
	void Update () {

		moveVector = Vector3.zero;

		if (controller.isGrounded) 
		{
			verticalVelocity = -gravity * Time.deltaTime; //add gravity to the character.
			if(Input.GetKeyDown(KeyCode.Space))
			{
				verticalVelocity = jumpForce;
			}
		} 
		else 
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}	
			
		moveVector.x = Input.GetAxisRaw("Horizontal")*speed;//x = left and right
		moveVector.y = verticalVelocity;//y = up and down
		moveVector.z = currentSpeed;//z = forward and backward

		if(!isSprinting && !isBoosted){
			currentSpeed = speed;
			staminaBar.value += Time.deltaTime / staminaRegainrate * staminaReganinMult;
		}

		if(isSprinting && !isBoosted) {
			currentSpeed = sprintSpeed;
			staminaBar.value -= Time.deltaTime / staminaFallrate * staminaFallMult;

		}
		if (isSprinting && isBoosted) {
			currentSpeed = sprintSpeed;
			staminaBar.value -= Time.deltaTime / staminaFallrate * staminaFallMult;
			boostTime -= Time.deltaTime * boostTimeFallrate;
			Debug.Log (boostTime);
			if (boostTime <= 0) {
				isBoosted = false;
				currentSpeed = speed;
				boostTime = 20f;
			}
		}
		if (!isSprinting && isBoosted) {

			currentSpeed = sprintSpeed;
			staminaBar.value += Time.deltaTime / staminaRegainrate * staminaReganinMult;
			boostTime -= Time.deltaTime * boostTimeFallrate;
			Debug.Log (boostTime);
			if (boostTime <= 0) {
				isBoosted = false;
				currentSpeed = speed;
				boostTime = 20f;
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isSprinting = true;
			sprintSpeed = speed *2 ;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			isSprinting = false;
		}
		if (staminaBar.value >= maxStamina) 
		{
			staminaBar.value = maxStamina;

		} else if (staminaBar.value <= 0) 
		  {
			staminaBar.value = 0;
			sprintSpeed = speed;
		} 
		controller.Move(moveVector * Time.deltaTime);
	}

	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.name == "SpeedBoost") 
		{
			isBoosted = true;
			Debug.Log ("Boost");
		}
	}
}
