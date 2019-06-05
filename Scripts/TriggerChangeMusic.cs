using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeMusic : MonoBehaviour {

	public GameMusicScript musicScript;
	public AudioClip clipMusic;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			musicScript.ChangeMusicAndPlay (clipMusic);
	}

	void OnTriggerExit(Collider collider) {
	
		if (collider.gameObject.CompareTag ("Player"))
			musicScript.PlayMusicDefault ();
	}
}
