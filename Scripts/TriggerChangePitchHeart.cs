using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangePitchHeart : MonoBehaviour {

	public HeartPlayerPitchController heartPlayer;
	public float newPitch = 2f;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			heartPlayer.ChangePitch (newPitch);
			Destroy (gameObject);
		}
	}
}
