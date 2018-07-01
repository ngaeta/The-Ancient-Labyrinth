using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSecondLevel : MonoBehaviour {

	public GameObject[] gameObjectsToDestroy;
	public GameObject[] gameObjectsToActive;

	public void DestroyGameObjects() {
		foreach (GameObject g in gameObjectsToDestroy) {
			if(g!=null)
				Destroy (g);
		}
	}

	public void ActiveGameObjects() {
		foreach (GameObject g in gameObjectsToActive)
			g.SetActive (true);
	}
}
