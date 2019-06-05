using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteraction : MonoBehaviour {

	public MouseCursor mouseCursorScript;

	void OnTriggerEnter(Collider collider) {
		if (collider.CompareTag ("Player"))
			mouseCursorScript.enabled = true;
	}

	void OnTriggerExit(Collider collider) {
		if (collider.CompareTag ("Player")) {
			mouseCursorScript.enabled = false;
		}
	}
}
