using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {

	public GameObject Box;
	private Renderer rend;

	public bool hit = false;

	// Use this for initialization
	void Start () {
		rend = Box.GetComponent<Renderer> ();
		rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hit) {
			return;
		}
		if (hit) {
			GetHit ();
		}
	}

	void GetHit(){
		
		Box.AddComponent <Rigidbody> ();
		Debug.Log ("HIT");
		StartCoroutine ("Wait");

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (1);
		Destroy (Box);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Monster") {
			rend.enabled = true;
			hit = true;
		}
	}
}
