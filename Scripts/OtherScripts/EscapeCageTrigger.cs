using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeCageTrigger : MonoBehaviour {

	public MonsterAttackTempleScripting m;

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.CompareTag ("Player")) {
			if (m != null) {
				Debug.Log ("Sta ancora attaccando");
				m.PlayerInCage = false;
			}
		}
	}
}
