using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToActiveAnimationEvent : MonoBehaviour {

	public GameObject[] objectsToActive;

	public void ActiveObjects() {
		foreach (GameObject g in objectsToActive)
			g.SetActive (!g.activeInHierarchy);
	}
}
