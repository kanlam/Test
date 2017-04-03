using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBox : MonoBehaviour {

	public GameObject water;
	private Rigidbody rigidbody;

	public int force;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > water.transform.position.y) {
			rigidbody.AddForce (-transform.up * force * 10);
		}
		if (transform.position.y < water.transform.position.y) {
			rigidbody.AddForce (transform.up * force * 10);
		}
	}
}
