using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class AttackPlayerScripting : MonoBehaviour {

	public IAMonsterController monsterIA;
	public Transform t;
	public bool m=false;
	public PlayerDead player;

	void OnTriggerStay(Collider collider) {
	
		if (collider.gameObject.CompareTag ("Player")) {
			collider.gameObject.GetComponent<FirstPersonController> ().enabled = false;
			collider.gameObject.transform.LookAt (t);
			monsterIA.Attack(collider.gameObject.transform);
			player.Dead ();
			Destroy (this);
		}
	}
}
