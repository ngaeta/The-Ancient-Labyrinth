using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMainLevel : MonoBehaviour {

	private static int scene = 0;
	AsyncOperation loadState;
	public Text text;
	public static string sceneToLoad;

	// Use this for initialization
	void  Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		StartCoroutine (Loading ());
	}

	private IEnumerator Loading() {
		Debug.Log ("NsCene" + scene);
		yield return new WaitForSecondsRealtime (1f);
		loadState = SceneManager.LoadSceneAsync (sceneToLoad);
		//loadState.allowSceneActivation = false;
		while (!loadState.isDone) {
			float progress = Mathf.Clamp01 (loadState.progress / .9f);
			text.text = "" + System.Math.Round(progress * 100, 0) + "%";
			yield return null;
		}
		//non va
		//Debug.Log ("SI");
		//loadState.allowSceneActivation = true;
	}
}
