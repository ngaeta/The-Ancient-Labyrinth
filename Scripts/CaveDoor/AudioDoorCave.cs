using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDoorCave : MonoBehaviour, DoorInterface {

	private AudioSource m_AudioSource;

	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
	}

	public void Open() {
		m_AudioSource.Play ();
	}

	public void Close() {
		m_AudioSource.loop = false;
		m_AudioSource.Stop ();
	}
}
