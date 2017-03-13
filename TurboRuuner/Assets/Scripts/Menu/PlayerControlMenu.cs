using UnityEngine;
using System.Collections;

public class PlayerControlMenu : MonoBehaviour{

	private CharacterController Controller;
	private float verticalVelocity = 0.0f;
	private float gravity = 14.0f;
	public float jumpForce; 

	public EnterConfirmWorld enterconfirmfireworld;
	public EnterConfirmWorld enterconfirmoceanworld;

	private void Start(){
		Controller = GetComponent<CharacterController>();
	}

    private void Update(){
      Vector3 moveVector = Vector3.zero;

	  if (Controller.isGrounded) 
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

	  moveVector.x = Input.GetAxis("Horizontal")*5;
	  moveVector.y = verticalVelocity;
	  moveVector.z = Input.GetAxis("Vertical")*5 ;

	  Controller.Move(moveVector * Time.deltaTime);
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