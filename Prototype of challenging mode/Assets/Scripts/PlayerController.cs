using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private CharacterController controller;
	private Vector3 moveVector;

	public float speed;
	public float jumpForce; 
	public float maxStamina = 3.0f;
	public float currentStamina =3.0f;

	private float verticalVelocity = 0.0f;
	private float gravity = 14.0f;

	//private float currentStamina = 3.0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
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

		//x = left and right
		moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
		//y = up and down
		moveVector.y = verticalVelocity;
		//z = forward and backward
		moveVector.z = speed;

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (currentStamina > 0) {
				speed *= 2;
				currentStamina -= Time.deltaTime;
				Debug.Log (currentStamina);
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
				speed = speed / 2;
				currentStamina = Mathf.Clamp (currentStamina + Time.deltaTime, 0, maxStamina);
	
		controller.Move(moveVector * Time.deltaTime);
		
	}
}
