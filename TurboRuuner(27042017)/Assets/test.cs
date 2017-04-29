using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public bool ishit;
	public AudioSource hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.H)) {
			hit.Play ();
		}
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Cube") {
			ishit = true;
			hit.Play ();
		}
	}
	void OnTriggerExit(Collider other){
		ishit = false;
	}

}
