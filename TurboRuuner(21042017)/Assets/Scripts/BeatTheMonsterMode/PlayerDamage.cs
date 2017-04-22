using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	public int Health= 10;
	public bool isDead = false;

	public AudioSource hitsound;

	public DeadMenu deathMenu;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		OnDeath ();
	}
	
	void OnTriggerEnter(Collider hit){

		if (!isDead) {
			if (hit.gameObject.name == "Sphere(Clone)" || hit.gameObject.name == "Cylinder(Clone)") {
				Health = Health - 1;
				hitsound.Play ();
			}
		}
	}

	public void OnDeath()
	{
		if (Health <= 0) {
			isDead = true;
			deathMenu.ToggleDeathMenu ();
		}
	}
}
