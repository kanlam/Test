using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public enum AudioChannel {Master, Sfx, Music};

	public float masterVolumePercent = 1;
	public float sfxVolumePercent = 1;
	public float musicVolumePercent = 1;

	AudioSource[] musicSouces;
	int activeMusicSourceIndex;

	public static AudioManager instance;

	// create two audioSource at start
	void Awake(){

		instance = this;

		musicSouces = new AudioSource[2];
		for (int i = 0; i < 2; i++) {
			GameObject newMusicSource = new GameObject ("Music source" + (i + 1));
			musicSouces[i] = newMusicSource.AddComponent<AudioSource>();
			newMusicSource.transform.parent = transform;
		}

		masterVolumePercent = PlayerPrefs.GetFloat ("master vol", masterVolumePercent);
		sfxVolumePercent = PlayerPrefs.GetFloat ("sfx vol", sfxVolumePercent);
		musicVolumePercent = PlayerPrefs.GetFloat ("music vol", musicVolumePercent);
	}

	public void SetVolume(float volumePercent, AudioChannel channel){
		switch (channel) {
		case AudioChannel.Master:
			masterVolumePercent = volumePercent;
			break;
		case AudioChannel.Sfx:
			sfxVolumePercent = volumePercent;
			break;
		case AudioChannel.Music:
			musicVolumePercent = volumePercent;
			break;
		}
		musicSouces [0].volume = musicVolumePercent * masterVolumePercent;
		musicSouces [1].volume = musicVolumePercent * masterVolumePercent;

		PlayerPrefs.SetFloat ("master vol", masterVolumePercent);
		PlayerPrefs.SetFloat ("sfx vol", sfxVolumePercent);
		PlayerPrefs.SetFloat ("music vol", musicVolumePercent);
		PlayerPrefs.Save ();
	}

	public void PlayMusic(AudioClip clip, float fadeDuration =1){
		activeMusicSourceIndex = 1 - activeMusicSourceIndex;
		musicSouces [activeMusicSourceIndex].clip = clip;
		musicSouces [activeMusicSourceIndex].Play ();

		StartCoroutine (AnimateMusicCrossfade (fadeDuration));
	}

	public void PlayerSound(AudioClip clip, Vector3 pos){
		if (clip != null) {
			AudioSource.PlayClipAtPoint (clip, pos, sfxVolumePercent * masterVolumePercent);
		}
	}


	IEnumerator AnimateMusicCrossfade(float duration){
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * 1 / duration;
			musicSouces [activeMusicSourceIndex].volume = Mathf.Lerp (0, musicVolumePercent * masterVolumePercent, percent);
			musicSouces [1-activeMusicSourceIndex].volume = Mathf.Lerp (musicVolumePercent * masterVolumePercent,0, percent);

			yield return null;
		}
	}
}
