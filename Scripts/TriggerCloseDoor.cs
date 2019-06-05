using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour {

	public DoorFinalTempleController door;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			door.CloseDoor ();
			Destroy (gameObject);
		}
	}
}
