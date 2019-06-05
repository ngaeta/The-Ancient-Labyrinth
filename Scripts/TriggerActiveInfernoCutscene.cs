using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActiveInfernoCutscene : MonoBehaviour {

	public CutscenesController cutsceneController;
	public DemonHellController demonController;
	public CameraController cameraController;
	public AudioSource audioSource;
	public AudioSource[] audioToDeactive;
	public GameManager2 gameManager;
	public string nameSceneToLoad = "Credits";
	public Transform lookAt;
	public HeartPlayerPitchController heartPlayer;
	public float newPitchPlayer = 3f;
	public AudioClip clipCredits;


	void Start() {
		demonController.OnAnimationEndEvent += FinishGame;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			cutsceneController.StartCutscene ();
			collider.transform.LookAt (lookAt.transform);
			demonController.StartAnimation ();
			heartPlayer.ChangePitch (newPitchPlayer);
		}
	}

	private void FinishGame() {
		StartCoroutine (WaitToFinish ());
	}

	private IEnumerator WaitToFinish() {
		yield return new WaitForSecondsRealtime (demonController.getLenghtClipAudio () + 1);
		DeactiveAudio ();
		audioSource.Play ();
		demonController.PlayLaugh ();
		cameraController.ChangeLayer ("Nothing");
		heartPlayer.Stop ();
		Invoke ("LoadCredits", audioSource.clip.length - 2);
	}

	void OnDisable() {
		demonController.OnAnimationEndEvent -= FinishGame;
	}

	private void DeactiveAudio() {
		foreach (AudioSource a in audioToDeactive)
			a.Stop ();
	}

	private void LoadCredits() {
		GameManager2.SetAudioClipCredits (clipCredits);
		gameManager.LoadSceneDirectly (nameSceneToLoad);
	}
}
