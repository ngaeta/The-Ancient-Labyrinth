using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalEnter : MonoBehaviour {

	public GameManager gameManager;
	public CameraController camera;
	public CutscenesController cutscenesController;
	public AudioSource audioSource2D;
	public AudioClip clipPortalEnter;
	public float delayToLoad = 0f;
	public string sceneToLoad;
	public AudioSource[] audioSourceToDeactive;
	public Color colorBackgroundCamera;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			cutscenesController.StartCutscene ();
			DeactiveAudioSource ();
			camera.ChangeFlag (CameraClearFlags.SolidColor);
			camera.ChangeLayer ("Nothing");
			camera.ChangeColor (colorBackgroundCamera);
			audioSource2D.clip = clipPortalEnter;
			audioSource2D.Play ();
			Invoke ("LoadScene", clipPortalEnter.length + delayToLoad);
		}
	}

	private void LoadScene() {
		gameManager.LoadSceneDirectly (sceneToLoad);
	}

	private void DeactiveAudioSource() {
		foreach (AudioSource a in audioSourceToDeactive)
			a.Stop ();
	}
}
