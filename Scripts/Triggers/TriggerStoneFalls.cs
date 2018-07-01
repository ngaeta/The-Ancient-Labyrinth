using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStoneFalls : MonoBehaviour {

	public GameObject stoneToActive;
	public IAMonsterController iaMonster;
	public VisionMonsterTrigger vision;
	public GameObject[] gameObjectToDeactive;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			stoneToActive.SetActive (true);
			DeactiveGameObject ();
			Destroy (gameObject);
		}
	}

	private void DeactiveGameObject() {
		foreach(GameObject g in gameObjectToDeactive)
			g.SetActive(false);
	}
}
