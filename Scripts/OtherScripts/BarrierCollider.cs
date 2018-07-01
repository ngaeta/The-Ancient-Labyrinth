using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollider : MonoBehaviour {

	public IAMonsterController ia;
	public VisionMonsterTrigger vision;

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.CompareTag("Monster") && vision.PlayerSeen) {
			vision.PlayerLost();
			ia.LookAroundAndAfterWalk (null);
		}
	}
}
