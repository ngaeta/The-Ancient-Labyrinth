using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextWaypointMonster : MonoBehaviour {

	public NavMeshMonster nav;
	public IAMonsterController IAMonsterController;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Monster") && nav.currentZone == transform) {
			if (IAMonsterController.monsterState == MonsterAction.MONSTER_ACTION.WALK) {
				Debug.Log ("Mostro a " + gameObject.name);	
				nav.NextDestination ();;
			} 
		}
	}
}
