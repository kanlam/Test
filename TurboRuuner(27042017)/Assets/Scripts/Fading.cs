using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

	public static Fading Instance{ set; get; }

	public Image fadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;

	private void Awake(){
		Instance = this;
		Fade (false, 5f);
	}

	public void Fade(bool showing , float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
	}

	private void Update(){

		if (!isInTransition)
		return;

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		fadeImage.color = Color.Lerp (new Color (1,1,1,0), Color.white, transition);

		if (fadeImage.color.a == 0) {
			fadeImage.gameObject.SetActive (false);
		} else {
			fadeImage.gameObject.SetActive (true);
		}

		if (transition > 1 || transition < 0)
			isInTransition = false;
	}
}

