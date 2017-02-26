using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {
 
	public Image currentProgressbar;
	public Text ratioText;
	public bool start = false;

	public float progress = 0 ;

	float dist;
	float maxProgress;

	GameObject finishLine;
	 


	// Use this for initialization
	void Start () {
		maxProgress = 138;
		finishLine = GameObject.FindWithTag ("Finish");//find the finish line at the begining
	}
	
	// Update is called once per frame
	void Update () {
		Startdistance ();
		float ratio = (progress/maxProgress);
		currentProgressbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio*100).ToString ("0")+ "%";
		Debug.Log ("CurrentProgress: " + progress);
	}

	void Startdistance(){
		if (start) {
			dist = Vector3.Distance (finishLine.transform.position, transform.position);//tracking the distance
			progress = maxProgress-dist;
			Debug.Log ("Distance: " + dist);
		}
		if (!start) {
			return;
		}
	}


	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.name == "startRace") {
			Debug.Log ("StartDistance");
			start = true;
		}
		if (hit.gameObject.name == "finishRace") {
			Debug.Log ("EndDistance");
			start = false;
		}
	}
}
