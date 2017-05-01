using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	
	public AudioSource efxSource;					
	public AudioSource musicSource;					
	public AudioClip endSongSource;		
	public AudioClip ambientSource;				
	public static SoundManager instance = null;		
	public float lowPitchRange = .95f;				
	public float highPitchRange = 1.05f;			

	void Awake () {
		//Check if there is already an instance of SoundManager
		if (instance == null)
			instance = this;
		//If instance already exists:
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip) {
		efxSource.clip = clip;
		efxSource.Play ();
	}

	public void PlayEnding() {
		musicSource.clip = endSongSource;
		musicSource.Play ();
	}

	public void PlayMusic() {
		musicSource.clip = ambientSource;
		musicSource.Play ();
	}

	//RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
	public void RandomizeSfx (params AudioClip[] clips) {
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);
		efxSource.pitch = randomPitch;
		efxSource.clip = clips[randomIndex];
		efxSource.Play();
	}
}