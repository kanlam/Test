using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	private GameObject[] characterList;
	private int index;

	// Use this for initialization
	void Start () {

        index = PlayerPrefs.GetInt("CharacterSelected");

		characterList = new GameObject[transform.childCount];

		//Fill the array with our game models
		for (int i = 0; i < transform.childCount; i++) 
			characterList [i] = transform.GetChild (i).gameObject;

			// Toggle off the model's renderer
			foreach (GameObject go in characterList) 
				go.SetActive(false);
		   // Toggle on the selected model's renderer
		if (characterList [index])
			characterList [index].SetActive (true);
	}
	public void ToggleLeft(){

		characterList [index].SetActive (false);
		index--;
		if (index < 0)
			index = characterList.Length - 1;
		characterList [index].SetActive (true);
	}

	public void ToggleRight(){

		characterList [index].SetActive (false);
		index++;
		if (index == characterList.Length)
			index = 0;
		characterList [index].SetActive (true);
	}

	public void ConfirmBtnBM(){
		PlayerPrefs.SetInt("CharacterSelected", index);
		SceneManager.LoadScene("3)LevelSelectMenu(BM)");
	}
	public void ConfirmBtnCM(){
		PlayerPrefs.SetInt("CharacterSelected", index);
		SceneManager.LoadScene("4)LevelSelectMenu(CM)");
	}

}
