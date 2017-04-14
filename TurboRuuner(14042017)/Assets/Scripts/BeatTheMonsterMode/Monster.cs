using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public float speed = 1f;
	public bool isMove = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isMove) {
			move ();
		} 
		else {
			stop ();
		}


	}

	void move(){
		transform.Translate (0, 0, -speed*Time.deltaTime);
	}
	void stop (){
		transform.Translate (0, 0, 0);
		Destroy (GameObject.Find("Attack2"));
		Destroy (GameObject.Find("Attack1"));

	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.name == "MonsterStop") {
			isMove = false;		
		}	
	}

}
