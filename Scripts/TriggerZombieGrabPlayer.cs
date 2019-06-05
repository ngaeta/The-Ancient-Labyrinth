using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombieGrabPlayer : MonoBehaviour {
	
	public ZombieGrabPlayerCutscene zombieCutscene;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			zombieCutscene.StartCutscene ();
			Destroy (this);
		}
	}
}
