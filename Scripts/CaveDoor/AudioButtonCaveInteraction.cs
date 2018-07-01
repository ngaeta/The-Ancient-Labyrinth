using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtonCaveInteraction : MonoBehaviour {

	[SerializeField] private AudioClip clipPressed, clipReleased;
	private AudioSource m_AudioSource;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
	}


	public void PlayAudioPressed() {
		m_AudioSource.clip = clipPressed;
		m_AudioSource.Play ();
	}

	public void PlayAudioReleased() {
		m_AudioSource.clip = clipReleased;
		m_AudioSource.Play ();
	}
}
