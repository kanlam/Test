using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravity : MonoBehaviour {

	private CharacterController Controller;

	public float verticalVelocity = 0f;
	private float gravity = 14.0f;
	public float jumpForce;

	// Use this for initialization
	void Start () {
		Controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveVector = Vector3.zero;

		if (Controller.isGrounded) 
		{
			verticalVelocity = -gravity * Time.deltaTime; //add gravity to the character.
			if(Input.GetKeyDown(KeyCode.Space))
			{
				verticalVelocity = jumpForce;
			}
		} 
	}
}
