using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoorAudio : MonoBehaviour {

	private AudioSource m_AudioSource;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			Debug.Log ("si");
			m_AudioSource.Play ();
		}
	}
}
