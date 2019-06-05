using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStopMonster : MonoBehaviour {

	public IAMonsterController ia;
	public VisionMonsterTrigger vision;

	void OnTriggerEnter(Collider collider) {
		if (vision.PlayerSeen && collider.gameObject.CompareTag ("Player")) {
			Debug.Log ("Sine");
			vision.PlayerLost ();
			ia.LookAroundAndAfterWalk (null);
		}
	}
}
