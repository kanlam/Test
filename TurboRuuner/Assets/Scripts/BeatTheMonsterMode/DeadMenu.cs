using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

	public void ToggleDeathMenu()
	{
		gameObject.SetActive (true);

	}

}



