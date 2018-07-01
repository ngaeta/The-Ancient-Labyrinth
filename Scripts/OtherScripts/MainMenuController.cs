using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	private bool m_ButtonPressed;
	public GameObject PopUpExit;
	public GameObject menu;
	public GameObject options;
	public GameObject title;

	void Start() {
		AudioListener.pause = false;
		Time.timeScale = 1f;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		m_ButtonPressed = false;
	}

	public void NewGame() {
		LoadMainLevel.sceneToLoad = "Level1";
		SceneManager.LoadScene ("LoadingScene");
	}

	public void MainMenu() {
		LoadMainLevel.sceneToLoad = "MainMenu";
		SceneManager.LoadScene ("LoadingScene");
	}

	public void ExitGamePopUp() {
		title.SetActive (false);
		menu.SetActive (false);
		PopUpExit.SetActive (true);
	}

	public void ExitGame() {
		Application.Quit ();
	}

	public void ReturnMenu() {
		title.SetActive (true);
		menu.SetActive (true);
		PopUpExit.SetActive (false);
		options.SetActive (false);
	}

	public void ShowOptions() {
		title.SetActive (false);
		menu.SetActive (false);
		options.SetActive (true);
	}
}
