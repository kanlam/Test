﻿using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	private void OnTriggerEnter (Collider other){
		GameObject.Find ("Player").SendMessage("Finish");
	}
}
