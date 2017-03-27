using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

	public AudioMixer Mastermixer;
	public AudioMixerGroup BGM;
	public AudioMixerGroup SFX;


	public void SetMaster(float mastervol){
		Mastermixer.SetFloat ("MasterVolume", mastervol);

	}
	public void SetBGM(float bgmvol){
		BGM.audioMixer.SetFloat ("BgmVolume", bgmvol);
	}
	public void SetSFX(float sfxvol){
		SFX.audioMixer.SetFloat ("SfxVolume", sfxvol);
	}
}
