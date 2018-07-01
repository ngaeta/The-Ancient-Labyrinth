using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAudioInteraction : MonoBehaviour {

	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
	}

	public void FlameOn() {
		m_AudioSource.Play ();
	}
}
