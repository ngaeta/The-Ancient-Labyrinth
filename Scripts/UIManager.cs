using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour {

	public GameObject inventoryUI;
	public GameObject pauseUI;
	public FirstPersonController fps;
	private bool m_inventoryActive;
	private bool m_Paused;
	public GameObject pauseOptions;
	public GameObject panelExitConfirm;
	public GameObject[] UIToDeactive;

	public float timeToNextAction = 0.2f;
	private bool m_NextAction;

	void Start() {
		m_NextAction = true;
		m_inventoryActive = false;
		m_Paused = false;
	}

	public void OptionsPressed() {
		DeactiveObj (false);
		pauseOptions.SetActive (true);
	}

	public void BackPressed() {
		pauseOptions.SetActive (false);
		panelExitConfirm.SetActive (false);
		DeactiveObj (true);
	}

	private void DeactiveObj(bool value) {
		foreach (GameObject g in UIToDeactive)
			g.SetActive (value);
	}
		
	void Update() {
		if (Input.GetKeyUp (KeyCode.Escape))
			Pause ();
		else if (Input.GetMouseButtonUp (1) && inventoryUI != null && !pauseUI.activeInHierarchy && m_NextAction) {
			m_NextAction = false;
			ShowInventory ();
			StartCoroutine (WaitNextAction ());
		} else if (m_inventoryActive && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0))
			ShowInventory ();
	}
		
	public void Pause() {
		if (inventoryUI != null) {
			inventoryUI.SetActive (false);
			m_inventoryActive = false;
		}

		if (Time.timeScale != 0) {
			m_Paused = true;
			Time.timeScale = 0;
			AudioListener.pause = true;
			pauseUI.SetActive (true);
			fps.enabled = false;
		} else {
			m_Paused = false;
			Time.timeScale = 1;
			AudioListener.pause = false;
			pauseUI.SetActive (false);
			fps.enabled = true;
			DeactivePauseElement ();
		}
		ShowCursor (m_Paused);
	}


	public void ShowInventory () {
		fps.enabled = m_inventoryActive;
		m_inventoryActive = !m_inventoryActive;
		inventoryUI.SetActive (m_inventoryActive);
		ShowCursor (m_inventoryActive);
	}

	private void ShowCursor(bool value) {
		Cursor.visible = value;
		if(value) 
			Cursor.lockState = CursorLockMode.None;
		else
			Cursor.lockState = CursorLockMode.Locked;
	}

	void OnDisable() {
		pauseUI.SetActive (false);
		if(inventoryUI != null)
			inventoryUI.SetActive (false);
	}

	private void DeactivePauseElement() {
		if (pauseOptions.activeSelf) {
			pauseOptions.SetActive (false);
			DeactiveObj (true);
		}
		if (panelExitConfirm.activeSelf) {
			panelExitConfirm.SetActive (false);
			DeactiveObj (true);
		}
	}

	public void ExitPressed() {
		DeactiveObj (false);
		panelExitConfirm.SetActive (true);
	}

	private IEnumerator WaitNextAction() {
		yield return new WaitForSecondsRealtime (timeToNextAction);
		m_NextAction = true;
	}
}
