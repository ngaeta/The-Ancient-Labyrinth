using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaTeletrasporto : MonoBehaviour {

	public Transform newPos;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			collider.transform.position = newPos.position;
	}
}
