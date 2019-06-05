using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWoodBridge : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip[] clipAudioBridge;
	public float[] timeToNextBridge;

	private int nextBridge;

	void Start() {
		nextBridge = 0;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			PlayAudio ();
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			CancelInvoke ();
		}
	}

	private void PlayAudio() {
		audioSource.clip = clipAudioBridge [nextBridge];
		audioSource.Play ();
		nextBridge = (nextBridge + 1) % timeToNextBridge.Length;
		Invoke ("PlayAudio", timeToNextBridge [nextBridge]);
	}
}
