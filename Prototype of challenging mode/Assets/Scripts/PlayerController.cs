using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	private CharacterController controller;
	private Vector3 moveVector;

	public float speed;
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

	//private float currentStamina = 3.0f;

	// Use this for initialization
	void Start () {
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
		if(!isSprinting){
			moveVector.z = speed;
			staminaBar.value += Time.deltaTime / staminaRegainrate * staminaReganinMult;
		}//z = forward and backward

		if(isSprinting) {
			moveVector.z = sprintSpeed;
			staminaBar.value -= Time.deltaTime / staminaFallrate * staminaFallMult;
		}//z = forward and backward



		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isSprinting = true;
			sprintSpeed = speed *2 ;

		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			isSprinting = false;

		}
		if (staminaBar.value >= maxStamina) {
			staminaBar.value = maxStamina;

		} else if (staminaBar.value <= 0) 
		  {
			staminaBar.value = 0;
			sprintSpeed = speed;

		} else if (staminaBar.value >= 0) 
		  {
			sprintSpeed = sprintSpeed;
		}

		controller.Move(moveVector * Time.deltaTime);
		
	}
}
