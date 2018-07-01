using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AudioWaterSplash : MonoBehaviour {

	private AudioSource m_AudioSource;
	private bool m_AlreadyInWater;

	public FirstPersonController fps;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		m_AlreadyInWater = false;
	}
	
	void OnTriggerEnter(Collider collider) {
		
		Debug.Log (Vector3.Distance(collider.transform.position, transform.position));
		if (!m_AlreadyInWater && collider.gameObject.CompareTag ("Player") && !fps.IsPlayerOnGround()) {
			Debug.Log ("Impatto con Acqua");
			m_AlreadyInWater = true;
			m_AudioSource.Play ();
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			m_AlreadyInWater = false;
	}
}
