using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVoiceController: MonoBehaviour {

	protected AudioSource m_AudioSource;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
	}

	public virtual void Play(AudioClip clip) {
		m_AudioSource.clip = clip;
		m_AudioSource.Play ();
	}

	public virtual void Stop() {
		m_AudioSource.Stop ();
	}
}
