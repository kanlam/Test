using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	public AudioSource source;

	public AudioClip MainBGM;
	public AudioClip DeadBGM;
	public AudioClip WinBGM;

	public OceanWorldBMControl character;

	public bool isDead;
	public bool isWin;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
		source.clip = MainBGM;
		source.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void GetBool(){
		if (character.isDead) {
			isDead = true;
			character.source.clip = DeadBGM;
			character.source.Play ();
		} else {
			isDead = false;
		}
		if (character.isWin) {
			isWin = true;
			//source.clip = WinBGM;
			source.PlayOneShot (WinBGM);
		} else {
			isWin = false;
		}
	}*/
}
