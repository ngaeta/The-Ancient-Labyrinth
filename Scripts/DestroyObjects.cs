using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

	public GameObject[] objectsToDestroy;

	public void Destroy() {
		foreach (GameObject g in objectsToDestroy)
			Destroy (g);
	}
}
