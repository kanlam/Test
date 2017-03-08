using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject optionMenuHolder;

	public Slider[] volunmeSliders;
	public Toggle[] resolutionTogglse;
	public int[] screenWidths;

	int activeScreenResIndex;


	void Start(){
		optionMenuHolder.SetActive (false);
		activeScreenResIndex = PlayerPrefs.GetInt ("screen res index");
		bool isFullscreen = (PlayerPrefs.GetInt ("fullscreen") == 1)?true:false; 

		volunmeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volunmeSliders [1].value = AudioManager.instance.musicVolumePercent;
		volunmeSliders [2].value = AudioManager.instance.sfxVolumePercent;

		for (int i = 0; i < resolutionTogglse.Length; i++) {
			resolutionTogglse [i].isOn = i == activeScreenResIndex;
		}
	
		SetFullScreen (isFullscreen);
	}



	//Start Game Button
	public void NewGameBtn(string BeatTheMonsterMode){
	 SceneManager.LoadScene ("BeatTheMonsterMode", LoadSceneMode.Single);
	}

	// Quit game Button
	public void QuitGameBtn(){
		Application.Quit();
	}

	public void OptionMenu(){
		optionMenuHolder.SetActive (true);
	}

	public void backToMainMenu(){
		optionMenuHolder.SetActive (false);
	}

	public void SetScreenResolution(int i){
		if (resolutionTogglse [i].isOn) {
			activeScreenResIndex = i;
			float Ratio = 16 / 9f;	
			Screen.SetResolution (screenWidths [i], (int)(screenWidths[i]/Ratio), false);
			PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
			PlayerPrefs.Save ();
		}
	}
	public void SetFullScreen(bool isFullscreen){
		for (int i = 0; i < resolutionTogglse.Length; i++) {
			resolutionTogglse [i].interactable = !isFullscreen;
		}

		if (isFullscreen) {
			Resolution[] allResolution = Screen.resolutions;
			Resolution maxResolution = allResolution [allResolution.Length - 1];
			Screen.SetResolution (maxResolution.width, maxResolution.height, true);
		} else {
			SetScreenResolution (activeScreenResIndex);	
		}
		PlayerPrefs.SetInt ("fullscreen", ((isFullscreen) ? 1 : 0));
		PlayerPrefs.Save ();
	}

	public void SetMasterVolume(float value){
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Master);
	}
	public void SetBGMVolume(float value){
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Music);
	}
	public void SetSfxVolume(float value){
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Sfx);
	}

}
