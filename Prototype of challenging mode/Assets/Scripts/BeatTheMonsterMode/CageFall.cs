using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageFall : MonoBehaviour {

	public bool isFall = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFall) {
			Fall();
		}
	}

	public void Fall(){
		isFall = true;
		Rigidbody Cage = gameObject.AddComponent<Rigidbody> () as Rigidbody;
	}
}
