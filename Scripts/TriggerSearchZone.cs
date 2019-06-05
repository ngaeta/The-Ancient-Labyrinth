using UnityEngine;
using System.Collections;

public class TriggerSearchZone : MonoBehaviour {

	private bool monsterAlreadySearch = false;
	public IAMonsterController IAMonsterController;
	public NavMeshMonster nav;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Monster") && nav.currentZone == transform) {
			if (IAMonsterController.monsterState == MonsterAction.MONSTER_ACTION.WALK) {
				Debug.Log ("Mostro a " + gameObject.name);	
				nav.NextDestination ();
				IAMonsterController.LookAroundAndAfterWalk (null);
			} 
		}
	}

	/*void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Monster")) {
			monsterAlreadySearch = false;
		}
	}*/
}
