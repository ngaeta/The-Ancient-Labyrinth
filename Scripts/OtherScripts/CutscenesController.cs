using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CutscenesController : MonoBehaviour {

	public CharacterController c;
	public TorchController torch;
	public FirstPersonController fpsScript;
	public UIManager uiManagerScript;
	public bool stopTorch = false;



	public void StartCutscene() {
		if(stopTorch && torch.torch.activeSelf)
			torch.SwitchTorch ();
		fpsScript.enabled = false;
		c.enabled = false;
		uiManagerScript.enabled = false;
	}

	public void StopCutscene() {
		if (stopTorch && !torch.torch.activeSelf) {
			torch.SwitchTorch ();
			stopTorch = false;
		}
		c.enabled = true;
		fpsScript.enabled = true;
		uiManagerScript.enabled = true;
	}
}
