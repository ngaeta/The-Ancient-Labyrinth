using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFinalTempleAudioController : MonoBehaviour {

	private AudioSource m_AudioDoor;
	public AudioClip clipClosing;
	public AudioClip clipOpened;

	// Use this for initialization
	void Start () {
		m_AudioDoor = GetComponent<AudioSource> ();
	}

	public void PlayAudioDoorOpened() {
		m_AudioDoor.clip = clipOpened;
		m_AudioDoor.Play ();
	}
	
	public void PlayAudioDoorClosed() {
		m_AudioDoor.clip = clipClosing;
		m_AudioDoor.Play ();
	}
}
