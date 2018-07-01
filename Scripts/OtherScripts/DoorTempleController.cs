using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTempleController : MonoBehaviour {

	public Animator m_animator;

	private AudioSource m_AudioSource;
	private int m_KeyAdded = 0;
	public int numberKeyNeeded = 2;

	void Start() {
		m_animator = GetComponent<Animator> ();
		m_AudioSource = GetComponent<AudioSource> ();
	}

	public void KeyAdded() {
		if (++m_KeyAdded == numberKeyNeeded) {
			m_animator.enabled = true;
		}
	}

	public void StopAudio() {
		m_AudioSource.Stop ();
	}

	public void StartAudio() {
		m_AudioSource.Play ();
	}
}
