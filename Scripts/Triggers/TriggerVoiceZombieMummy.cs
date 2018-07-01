using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVoiceZombieMummy : MonoBehaviour {

	public ZombieMummyController zombie;
	public float[] timeToNextRoar;
	public GameObject monsterToDestroy;
	public GameObject[] objectToActiveOnDestroy;

	private bool m_CanRoar;
	private bool m_CanDestroyMonster;

	void Start() {
		m_CanRoar = true;
	}

	void OnTriggerStay(Collider collider) {
		if (m_CanRoar && collider.gameObject.CompareTag ("Player")) {
			if (!zombie.IsAttacking) {
				m_CanRoar=false;
				zombie.NextRoar ();
				StartCoroutine (WaitToNextRoar (timeToNextRoar [Random.Range (0, timeToNextRoar.Length)]));
			}
		}
	}

	void OnTriggerExit(Collider collider) {
		if (m_CanDestroyMonster && collider.gameObject.CompareTag ("Player")) {
			Destroy (monsterToDestroy);
			ActiveGameObjects ();
			Destroy (gameObject);
		}
	}

	private IEnumerator WaitToNextRoar(float timeToWait) {
		yield return new WaitForSecondsRealtime (timeToWait);
		m_CanRoar = true;
	}

	public void CanDestroyMonster() {
		m_CanDestroyMonster = true;
	}

	private void ActiveGameObjects() {
		foreach (GameObject g in objectToActiveOnDestroy)
			g.SetActive (true);
	}	
}
