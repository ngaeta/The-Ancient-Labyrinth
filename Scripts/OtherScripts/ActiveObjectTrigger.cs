using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectTrigger : MonoBehaviour {

	public GameObject[] gameObjectToActive;

	private bool m_AlreadyActive;

	void Start() {
		m_AlreadyActive = false;
	}

	void OnTriggerEnter(Collider collider) {
		if (!m_AlreadyActive && collider.gameObject.CompareTag ("Player"))
			ActiveObjects (true);
	}

	void OnTriggerExit(Collider collider) {
		if (m_AlreadyActive && collider.gameObject.CompareTag ("Player"))
			ActiveObjects (false);

	}

	private void ActiveObjects(bool value) {
		foreach (GameObject g in gameObjectToActive) {
			if(g != null)
				g.SetActive (value);
		}
	}
}
