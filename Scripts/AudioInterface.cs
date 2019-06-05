using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInterface : MonoBehaviour {

	private AudioSource m_AudioSource;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
	}

	public virtual void Play() {
		if(!m_AudioSource.isPlaying)
			m_AudioSource.Play ();
	}

	public virtual void Stop() {
		m_AudioSource.Stop ();
	}
}
