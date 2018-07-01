using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMummySarcophagusScreams : MonoBehaviour {

	public AudioSource screams;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			screams.Play ();
			Destroy (this);
			//Distruggi tutti i trigger dopo che è finito audio
		}
	}
}
