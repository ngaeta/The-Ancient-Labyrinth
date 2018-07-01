using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiSarcophagusEnigmaAudio : MonoBehaviour {

	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		AnubiSarcophagusEnigma.OnEnigmaResolved += PlayAudioEnigma;
	}

	public void PlayAudioEnigma() {
		m_AudioSource.Play();
	}


	void Enable() {
		AnubiSarcophagusEnigma.OnEnigmaResolved += PlayAudioEnigma;
	}

	void Disable() {
		AnubiSarcophagusEnigma.OnEnigmaResolved -= PlayAudioEnigma;
	}
}
