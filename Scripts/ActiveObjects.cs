using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjects : MonoBehaviour {

	public GameObject[] objectsToActive;
	public bool DestroyObject = false;

	public void Active() {
		foreach (GameObject g in objectsToActive) {
			g.SetActive (true);
		}
	}

	public void Deactive() {
		foreach (GameObject g in objectsToActive) {
			if (DestroyObject)
				Destroy (g);
			else
				g.SetActive (false);
		}
	}
}
