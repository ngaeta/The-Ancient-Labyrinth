using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AudioObjectTrigger : MonoBehaviour {

	private AudioSource m_AudioSource;
	public FirstPersonController fps;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
	}
	
	void OnTriggerStay(Collider collider) {
		if (collider.gameObject.CompareTag ("Player") && !fps.IsStopped && !m_AudioSource.isPlaying) {
			
			m_AudioSource.Play ();
		}
	}
}
