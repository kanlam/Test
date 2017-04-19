using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Monster") {
			Destroy (this.gameObject);
		}
	}
}
