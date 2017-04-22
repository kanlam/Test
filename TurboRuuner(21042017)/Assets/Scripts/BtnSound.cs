using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSound : MonoBehaviour {

	public AudioClip ClickSound;

	private Button button {
		get{ 
			return GetComponent<Button> ();
		}
	}

	private AudioSource source {
		get{ 
			return GetComponent<AudioSource> ();
		}
	}

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();
		source.clip = ClickSound;
		source.playOnAwake = false;

		button.onClick.AddListener (() => PlaySound ());
	}

	public void PlaySound()
	{
		source.PlayOneShot (ClickSound);
	}
}
