using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWall : MonoBehaviour {


	private AudioSource m_AudioSource;
	private BoxCollider m_BoxCollider;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		m_BoxCollider = GetComponent<BoxCollider> ();
	}

	void OnTriggerExit(Collider collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			m_AudioSource.Play ();
			m_BoxCollider.isTrigger = false;
			Destroy (this);
		} else if (collision.gameObject.name.Equals ("Spider"))
			m_AudioSource.Play ();
	}
}
