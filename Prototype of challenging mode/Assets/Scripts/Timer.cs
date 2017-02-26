using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class timer : MonoBehaviour {
	public Text timerLabel;
	public float startTimer = 0;

	private float time;
	
	void Update() {


		if (startTimer > 0) {
			time += Time.deltaTime;
		
			var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
			var seconds = time % 60;//Use the euclidean division for the seconds.
			var fraction = (time * 100) % 100;

			//Debug.Log (time);
		
			//update the label value
			timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
		} 
	}

	void OnTriggerEnter(Collider hit) {
		if(hit.gameObject.name == "startRace")
		{
			Debug.Log ("Start");
			setTimer(1);//start the timer
		}

		if(hit.gameObject.name == "finishRace")
		{
			Debug.Log ("Finish");
			setTimer(0);// stop the timer

			if (time <= 14) { //gold time (0:00 - 00:14:00)
				timerLabel.color = Color.blue;
			}
			if (time > 14 && time <= 20) { //sliver time (00:14:01 - 00:20:00)
				timerLabel.color = Color.red;
			}
			if (time > 20) { // bronze time  (>00:20:00)
				timerLabel.color = Color.green;
			}
		}
	}

	void setTimer(int t){
		timer playerTimer = this.GetComponent<timer>();
		playerTimer.startTimer = t;
	}
}




