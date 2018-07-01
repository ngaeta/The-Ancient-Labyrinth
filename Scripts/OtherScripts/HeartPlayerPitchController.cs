using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPlayerPitchController : MonoBehaviour {

	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
	}
	
	public void ChangePitch(float newPitch) {
		m_AudioSource.pitch = newPitch;
	}

	public void Stop() {
		m_AudioSource.Stop ();
	}
}
