using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageFall : MonoBehaviour {

	public bool isFall = false;
	public bool Falled = false;

	public WinMenu winMenu;
	public bool isWin = false;
	public float waitTime = 2f;

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
		Invoke ("callToMenu", waitTime);

	}

	public void callToMenu(){
		winMenu.ToggleWinMenu ();
	}

	/*IEnumerator WaitMenu()
	{
		
		Debug.Log ("Waiting");
		yield return new WaitForSeconds (2f);
		Debug.Log ("WaitingEnd");
	}*/
}
