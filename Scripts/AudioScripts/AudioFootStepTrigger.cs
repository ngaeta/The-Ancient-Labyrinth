using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AudioFootStepTrigger : MonoBehaviour {

	public FirstPersonController fps;
	public AudioClip[] clipsGround;
	public AudioClip clipLand;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			fps.ChangeAudioFootStep (clipsGround, clipLand);
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			fps.DefaultFootStep ();
	}
}
