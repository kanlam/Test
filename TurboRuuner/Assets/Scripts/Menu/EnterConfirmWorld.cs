using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterConfirmWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame

	public void ToggleMenuFire()
	{
		gameObject.SetActive (true);
	}

	public void ToggleMenuOcean()
	{
		gameObject.SetActive (true);
	}

	public void YesbtnFireBM(){
		SceneManager.LoadScene("FireWorld(BM)");
	}
	public void YesbtnOceanBM(){
		SceneManager.LoadScene("OceanWorld(BM)");
	}
	public void YesbtnFireCM(){
		SceneManager.LoadScene("OceanWorld(CM)");
	}
	public void YesbtnOceanCM(){
		SceneManager.LoadScene("FireWorld(CM)");
	}

	public void Nobtn(){
		gameObject.SetActive (false);
	}
}
