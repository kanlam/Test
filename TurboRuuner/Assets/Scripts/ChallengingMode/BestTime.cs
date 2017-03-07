using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTime : MonoBehaviour {

	public Text bestTimetext;
	private float time;


	// Use this for initialization
	void Start () {
		time = PlayerPrefs.GetFloat ("BestTime");
		var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = time % 60;//Use the euclidean division for the seconds.
		var fraction = (time * 100) % 100;
		bestTimetext.text = "Best time Record\n" + 
		string.Format ("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
					
		}
	}

