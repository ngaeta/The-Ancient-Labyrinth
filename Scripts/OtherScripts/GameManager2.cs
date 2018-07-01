using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour {

	public UIManager ui;
	private static AudioClip clipCredits = null;

	void Start() {
		AudioListener.pause = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void LoadSceneDirectly(string name) {
		AudioListener.pause = false;
		SceneManager.LoadScene (name);
	}

	public void LoadScene(string name) {

		if (ui.enabled) 
			ui.Pause ();
		AudioListener.pause = false;
		LoadMainLevel.sceneToLoad = name;
		SceneManager.LoadScene ("LoadingScene");
	}

	public static void SetAudioClipCredits(AudioClip credits) {
		clipCredits = credits;
	}

	public static AudioClip GetAudioClipCredits() {
		return clipCredits;
	}
}

