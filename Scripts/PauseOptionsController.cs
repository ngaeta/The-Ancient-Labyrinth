using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptionsController : MonoBehaviour {


	public GameObject pauseOptions;
	public GameObject[] UIToDeactive;

	public void OptionsPressed() {
		DeactiveObj (false);
		pauseOptions.SetActive (true);
	}

	public void BackPressed() {
		pauseOptions.SetActive (false);
		DeactiveObj (true);
	}

	private void DeactiveObj(bool value) {
		foreach (GameObject g in UIToDeactive)
			g.SetActive (value);
	}
}
