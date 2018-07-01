using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractionWhiteSphere : TriggerInteraction {

	public GameObject sphereToActive;
	public GameObject lightToControl;   //white sphere becomes visible if light is off

	void OnTriggerStay(Collider collider) {
		if (!lightToControl.activeInHierarchy && collider.CompareTag ("Player")) {
			sphereToActive.SetActive (true);
			mouseCursorScript.enabled = true;
		} else if (lightToControl.activeInHierarchy && collider.CompareTag ("Player")) {
			sphereToActive.SetActive (false);
			mouseCursorScript.enabled = false;
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.CompareTag ("Player")) {
			sphereToActive.SetActive (false);
			mouseCursorScript.enabled = false;
		}
	}
}
