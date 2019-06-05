using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWaypointMonster : MonoBehaviour {

	public bool DeleteOnceArrived = true;
	public VisionMonsterTrigger visionMonster;
	public IAMonsterController IAMonsterController;
	public NavMeshMonster nav;

	void OnTriggerEnter(Collider collider) {
	
		if (collider.gameObject.CompareTag ("Monster")) {
			Debug.Log ("Si");
			if (!visionMonster.PlayerSeen) {
				IAMonsterController.LookAroundAndAfterWalk (null);
			}
			if (DeleteOnceArrived)	
				Destroy (gameObject);
		}
	}
}
