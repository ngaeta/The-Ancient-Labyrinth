using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTimer : MonoBehaviour {

	private AudioSource m_AudioSource;

	void Awake () {
		m_AudioSource = GetComponent<AudioSource> ();
	}

	public void Play() {
		m_AudioSource.Play ();
	}

	public void Stop() {
		m_AudioSource.Stop ();
	}
}
