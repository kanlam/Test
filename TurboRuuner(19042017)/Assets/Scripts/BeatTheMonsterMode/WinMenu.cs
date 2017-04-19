using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour {

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

	public void ToggleWinMenu()
	{
		gameObject.SetActive (true);
	}

}
