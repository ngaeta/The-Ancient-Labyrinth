using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CrouchPlayerTrigger : MonoBehaviour {

	public float YHeightCrouch = 1f, YPositionCrouch = 0.5f;

	public FirstPersonController fpsPlayer;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			fpsPlayer.Crouch (YHeightCrouch, YPositionCrouch);
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			fpsPlayer.GetUp ();
			//Destroy (gameObject);
		}
	}
}
