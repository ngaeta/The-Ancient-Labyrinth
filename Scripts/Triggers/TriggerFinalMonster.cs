using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalMonster : MonoBehaviour {

	public GameObject terrainToDestroy;
	public Animator doorStone;
	public AudioSource audio2D;
	public AudioClip clipRoarDistance;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Monster")) {
			Destroy (collider.gameObject);
			Destroy (terrainToDestroy);
			audio2D.loop = false;
			audio2D.clip = clipRoarDistance;
			audio2D.Play ();
			StartCoroutine (WaitToOpenDoor ());
		}
	}

	private IEnumerator WaitToOpenDoor() {
		yield return new WaitForSecondsRealtime (clipRoarDistance.length + 2f);
		doorStone.enabled = true;
		Destroy (gameObject);
	}
}
