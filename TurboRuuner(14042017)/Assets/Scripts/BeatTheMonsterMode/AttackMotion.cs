using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMotion : MonoBehaviour {

	 float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, -speed*Time.deltaTime);
	}

	void OnTriggerEnter (Collider hit){
		if (hit.gameObject.name == "End") {
			Destroy (this.gameObject);
		}
	}

}

