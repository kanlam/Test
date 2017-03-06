using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour {

	public GameObject button;
	public bool isPress = false;
	public bool activateButton = false;

	public GameObject cage;

	void Start(){
		cage = GameObject.Find ("Cage");	
	}

	// Update is called once per frame
	void Update () {


		if (isPress && activateButton) {
			button.transform.Translate (Vector3.down * Time.deltaTime);
			cage.AddComponent<Rigidbody> () as Rigidbody;

		}
		if (button.transform.position.y <= 0 ) {
			activateButton = false;
		}
	}

	void OnTriggerEnter (Collider hit)
	{
		if (hit.gameObject.name == "Player") {
			isPress = true;
			activateButton = true;

		} 
	}
}
