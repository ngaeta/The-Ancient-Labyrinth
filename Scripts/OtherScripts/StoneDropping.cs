using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDropping : MonoBehaviour {

	private AudioSource audioStone;

	public AudioClip clipOnGround;
	public AudioSource stoneDroppingAudio;

	void Start() {
		audioStone = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Terrain")) {
			GetComponent<Rigidbody> ().isKinematic = true;
			audioStone.clip = clipOnGround;
			audioStone.Play ();
			stoneDroppingAudio.Play ();
			Destroy (this);
		}
	}
}
