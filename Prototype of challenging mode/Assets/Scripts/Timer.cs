using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text Timertext;
	private float Starttime;
	private bool finished = false;

	// Use this for initialization
	void Start () {
		Starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (finished)
			return;
		
		float t = Time.time - Starttime;

		string hour = ((int)t / 60 / 60).ToString();
		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString ("f2");

		Timertext.text = "Time:"+ hour + ":" + minutes + ":" + seconds;
	}
	public void Finish(){
		finished = true;
		Timertext.color = Color.cyan;

	}
}
