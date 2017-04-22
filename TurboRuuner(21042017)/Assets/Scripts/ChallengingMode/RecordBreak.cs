using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordBreak : MonoBehaviour {

	float oldtime;
	float newtime;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
		oldtime = PlayerPrefs.GetFloat ("BestTime");
		Debug.Log ("OldTime: "+  oldtime + " NewTime: " + newtime);
		updateTime ();
		}


	void updateTime(){
		newtime = PlayerPrefs.GetFloat ("BestTime");
		return;
	}
} 


