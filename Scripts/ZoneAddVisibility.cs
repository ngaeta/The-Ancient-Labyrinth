using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAddVisibility : MonoBehaviour {

	public VisionMonsterTrigger visionMosnter;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			visionMosnter.AddVisibility ();
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			visionMosnter.ReduceVisibility ();
		}
	}
}
