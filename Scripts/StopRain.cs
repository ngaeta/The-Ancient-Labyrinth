using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRain : MonoBehaviour {

	public GameObject rainPlayer;
	public GameObject rainToActive;

	void OnTriggerEnter(Collider collider) {
		if (rainPlayer.activeInHierarchy && collider.gameObject.CompareTag ("Player")) {
			rainPlayer.SetActive (false);
			rainToActive.SetActive (true);
		}
	}

	void OnTriggerExit(Collider collider) {
		if (!rainPlayer.activeInHierarchy && collider.gameObject.CompareTag ("Player")) {
			rainPlayer.SetActive (true);
			rainToActive.SetActive (false);
		}
	}
}
