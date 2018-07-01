using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWallTrapTrigger : MonoBehaviour {

	public WallTrapTempleStatueController wallTrap;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			wallTrap.CloseDoor ();
			Destroy (gameObject);
		}
	}

}
