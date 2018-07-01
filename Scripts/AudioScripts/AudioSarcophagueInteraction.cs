using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSarcophagueInteraction : MonoBehaviour {

	private AudioSource m_AudioSource;

	public AudioClip clipOnGround;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		DoorSarcophagueInteraction.clickEvent += Play;
		DoorSarcophague.OnExplode += ClipOnGround;
	}

	void OnDisable() {
		DoorSarcophagueInteraction.clickEvent -= Play;
		DoorSarcophague.OnExplode -= ClipOnGround;
	}

	public void Play() {
		m_AudioSource.Play ();
	}

	public void ChangeClipAndPlay(AudioClip clip) {
		m_AudioSource.clip = clip;
		m_AudioSource.Play ();
	}

	public void ClipOnGround() {
		m_AudioSource.clip = clipOnGround;
		Play ();
	}
}
