using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneStartRain : MonoBehaviour {
	
	private bool m_ReadyToRain;
	public GameObject rainToActive;
	public GameObject thunderToActive;
	public float timeToWait = 5f;
	public GameObject stopRainActive;

	// Use this for initialization
	void Start () {
		m_ReadyToRain = false;
		GameManager.OnRainEvent += CanRain;
	}

	void OnTriggerEnter(Collider collider) {
		if (m_ReadyToRain && collider.gameObject.CompareTag ("Player")) {
			if (!rainToActive.activeInHierarchy && !thunderToActive.activeInHierarchy) {
				thunderToActive.SetActive (true);
				StartCoroutine (WaitToRain ());
			}
			else
				Destroy (this);
		}
	}

	public void CanRain() {
		m_ReadyToRain = true;
	}


	void OnDestroy() {
		Debug.Log ("OnDestory");
		GameManager.OnRainEvent -= CanRain;
	}


	void OnDisable() {
		GameManager.OnRainEvent -= CanRain;
	}

	private IEnumerator WaitToRain() {
		yield return new WaitForSecondsRealtime (timeToWait);
		rainToActive.SetActive (true);
		stopRainActive.SetActive (true);
		Destroy (this);
	}
}
