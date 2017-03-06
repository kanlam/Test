using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	public int Health = 10;
	public bool isDead = false;

	public AudioSource hitsound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0){
			isDead = true;
		}
    }

	void OnTriggerEnter(Collider hit){

		if (hit.gameObject.name == "Attack1(Clone)" || hit.gameObject.name == "Cylinder(Clone)" ) {
			Health = Health - 1;
			hitsound.Play ();
		}
	}


}
