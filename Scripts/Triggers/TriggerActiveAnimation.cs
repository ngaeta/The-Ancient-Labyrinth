using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActiveAnimation : MonoBehaviour {

	public Animator animatorToActive;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			animatorToActive.enabled = true;
			Destroy (this);
		}
	}
}
