using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	public int MaxHealth = 10;

	public AudioSource hitsound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
    }

	void OnTriggerEnter(Collider hit){

		if (hit.gameObject.name == "Attack1(Clone)") {
			MaxHealth = MaxHealth - 1;

			hitsound.Play ();
		}
	}		
}
