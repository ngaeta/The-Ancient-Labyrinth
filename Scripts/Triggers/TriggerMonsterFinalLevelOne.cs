using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonsterFinalLevelOne : MonoBehaviour {

	private bool m_IsAlreadyInTrigger;
	public IAMonsterController iaMonsterScript;
	public Transform objectToAttack;
	public AudioSource audio2D;
	public AudioClip clipHitDoor;
	public float timeRoarRepeat= 2.5f;
	public float numberHit = 5f;
	public GameObject grabPlayerToDeactive;
	public GameObject finalTarget;
	public GameMusicScript gameMusic;
	public SpawnLittleStones[] spawnStones;
	public AudioSource audioDroppingStones;
	private bool m_CanAttack;

	void Start() {
		FinalDoorController.onDoorClosed += StartAudioHitDoor;
		m_IsAlreadyInTrigger = false;
		m_CanAttack = false;
	}

	void OnTriggerStay(Collider collider) {
		if (!m_IsAlreadyInTrigger && collider.gameObject.CompareTag ("Monster")) {
			m_IsAlreadyInTrigger = true;
			iaMonsterScript.LookAround ();
			grabPlayerToDeactive.SetActive (false);
			InvokeRepeating ("RoarRepeating", 0f, timeRoarRepeat);
			m_CanAttack = true;
            //StartAudioHitDoor();
		}
	}

	public void StartAudioHitDoor() {
		StartCoroutine (WaitToMonsterArriveToTarget ());
	}
		
	private void RoarRepeating() {
		iaMonsterScript.Roar (objectToAttack);
	}

	private IEnumerator StartHit() {
		float actualHit = 0;
		while (actualHit < numberHit) {
			yield return new WaitForSecondsRealtime (clipHitDoor.length);
			audio2D.Play ();
			SpawnStones ();
			actualHit++;
		}
		yield return new WaitForSecondsRealtime (clipHitDoor.length);
		FinishHit ();
	}

	private void FinishHit() {
		finalTarget.SetActive (true);
		iaMonsterScript.Roar(finalTarget.transform);
		iaMonsterScript.WalkAtTarget (finalTarget.transform);
		gameMusic.Stopped = true;
	}

	private void SpawnStones() {
		foreach (SpawnLittleStones s in spawnStones)
			s.SpawnStones ();
		audioDroppingStones.Play ();
	}
		
	void OnDisable() {
		FinalDoorController.onDoorClosed -= StartAudioHitDoor;
	}

	private IEnumerator WaitToMonsterArriveToTarget() {
		while (!m_CanAttack)
			yield return new WaitForSecondsRealtime (1f);
		CancelInvoke ();
		audio2D.clip = clipHitDoor;
		StartCoroutine (StartHit ());
	}
}
