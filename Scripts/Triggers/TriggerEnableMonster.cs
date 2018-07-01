using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnableMonster : MonoBehaviour {

	public AudioSource audio2D;
	public GameObject[] gameObjectToActive;
	public AudioClip clipRoarMonster;
	public float secondsBeforeEnableGameObjects= 4f;
	private bool isActive=false;
    public GameMusicScript gameMusicScript;

	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player") && !isActive) {
			isActive = true;
			audio2D.clip = clipRoarMonster;
			audio2D.Play ();
			StartCoroutine (WaitToEnableGameObjects ());
		}
	}

	public IEnumerator WaitToEnableGameObjects() {
		yield return new WaitForSecondsRealtime (secondsBeforeEnableGameObjects);
        gameMusicScript.Play();
		foreach (GameObject g in gameObjectToActive)
			g.SetActive (true);

		Destroy (transform.parent.gameObject);
	}
}
