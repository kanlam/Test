using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {

	public GameObject Box;
	private Renderer rend;

	public bool hit;

	// Use this for initialization
	void Start () {
		rend = Box.GetComponent<Renderer> ();
		rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			return;
		}
	}


	void GetHit(){
		Box.AddComponent <Rigidbody> ();
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
			    GetHit ();

			}
	}
}
