using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCreditsController : MonoBehaviour {

	public AudioSource audioCredits;
	public AudioClip[] clips;

	// Use this for initialization
	void Start () {
		if (GameManager2.GetAudioClipCredits () != null) {
			audioCredits.clip = GameManager2.GetAudioClipCredits ();
		}

		audioCredits.Play ();
		Invoke ("NextClip", audioCredits.clip.length + 3);
	}

	private void NextClip() {
	
	}
}
