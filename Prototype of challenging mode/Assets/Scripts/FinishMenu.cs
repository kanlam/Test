using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour {

	public Text timeText;
	private float time;



	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = time % 60;//Use the euclidean division for the seconds.
		var fraction = (time * 100) % 100;
		timeText.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
	}

	public void ToggleMenu (float time)
	{
		this.time = time;
		gameObject.SetActive (true);

	}
}
