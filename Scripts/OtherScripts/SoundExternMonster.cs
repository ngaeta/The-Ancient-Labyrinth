using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundExternMonster : MonoBehaviour {

	public IAMonsterController ia;
	public VisionMonsterTrigger vision;
	public Transform monster;
	public float rangeSound = 15f;
	public Transform target;

	public void PlaySound() {
		if (!vision.PlayerSeen && Vector3.Distance (transform.position, monster.position) < rangeSound) {
			target.gameObject.SetActive (true);
			ia.RoarAndAfterRun (target);	
		}
	}
}
