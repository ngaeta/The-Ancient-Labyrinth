using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActiveGhost : MonoBehaviour {

	public GameObject ghostToActive;


	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			ghostToActive.SetActive (true);
			Destroy (gameObject);
		}
	}
}
