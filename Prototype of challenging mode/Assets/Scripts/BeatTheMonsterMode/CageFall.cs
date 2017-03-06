using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageFall : MonoBehaviour {

	public bool isFall = false;
	public bool Falled = false;

	public WinMenu winMenu;
	public bool isWin = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Falled){
			return;	
		}
		
		if (GameObject.Find ("ButtonA").GetComponent<PressButton> ().isPress) {			
			isFall = true;
			Fall ();
		}

	}


	public void Fall(){
		Rigidbody Cage = gameObject.AddComponent<Rigidbody> () as Rigidbody;
		Falled = true;
		isWin = true;
		winMenu.ToggleWinMenu ();
	}

}
