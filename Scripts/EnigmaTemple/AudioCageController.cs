using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCageController : MonoBehaviour {

	private AudioSource m_AudioSource;
	private bool m_CanPlay;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		m_CanPlay = false;
	}
	
	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.CompareTag ("Monster") && !m_AudioSource.isPlaying) {
			m_CanPlay = true;
			m_AudioSource.Play ();
		}
		else if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain") && m_CanPlay) {
			m_AudioSource.Play();
		}
	}
}
