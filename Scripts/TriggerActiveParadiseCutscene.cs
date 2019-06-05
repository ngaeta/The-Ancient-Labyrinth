using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class TriggerActiveParadiseCutscene : MonoBehaviour {

	public Animator lookAtAnimatorPlayer;
	public CutscenesController cutsceneController;
	public Transform positionToLookAt;
	public float timeToActiveLookAtAnimation = 1f;
	public float modifyBlur=  0.15f;
	public float modifyAudio = 0.2f;
	public BloomOptimized bloomScript;
	public AudioClip clipCredits;
	public AudioSource[] audioSourcesToDeactive;
	public GameManager2 gameManager;

	private bool m_CanBloom;
	private bool m_AlreadyInTrigger;
	public float sogliaBloom = -0.6f;

	void Start() {
		m_AlreadyInTrigger = false;
		m_CanBloom = false;
	}

	void OnTriggerEnter(Collider collider) {
		if (!m_AlreadyInTrigger && collider.gameObject.CompareTag ("Player")) {
			m_AlreadyInTrigger = true;
			cutsceneController.StartCutscene ();
			collider.transform.LookAt (positionToLookAt);
			StartCoroutine (WaitToActiveAnimation ());
		}
	}

	private IEnumerator WaitToActiveAnimation() {
		yield return new WaitForSecondsRealtime (timeToActiveLookAtAnimation);
		lookAtAnimatorPlayer.enabled = true;
		//yield return new WaitForSecondsRealtime (timeToActiveLookAtAnimation);
		m_CanBloom = true;
	}
		
	void Update() {
		if (m_CanBloom) {
			if (bloomScript.threshold > sogliaBloom) {
				bloomScript.threshold -= modifyBlur * Time.deltaTime;
				VolumeDown ();
				//abbassare tutti gli audio
			} else {
				GameManager2.SetAudioClipCredits (clipCredits);
				gameManager.LoadSceneDirectly ("Credits");
			}
		}
	}

	private void VolumeDown() {
		foreach (AudioSource a in audioSourcesToDeactive)
			a.volume-= modifyAudio * Time.deltaTime;
	}
}
