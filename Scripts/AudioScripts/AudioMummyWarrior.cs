using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMummyWarrior : MonoBehaviour {

	private AudioSource m_AudioSource;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		DoorSarcophague.OnExplode += PlayScream;
	}

	public void PlayScream() {
		m_AudioSource.Play ();
	}

	void OnDisable() {
		DoorSarcophague.OnExplode -= PlayScream;
	}

}
