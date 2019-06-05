using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CutscenesPlayerController : MonoBehaviour {

	public string TriggerNameChaliceAnimation = "Chalice";
	public Animator animator;

	public GameObject objectToTake;
	public GameObject shouldArm;
	public GameObject objectDestory;
	public CharacterController c;
	public TorchController torch;
	public FirstPersonController fpsScript;
	public UIManager uiManagerScript;
	public bool stopTorch = true;

	public void StartChaliceCutscene() {
		fpsScript.enabled = false;
		c.enabled = false;
		uiManagerScript.enabled = false;
		if(stopTorch && torch.torch.activeSelf)
			torch.SwitchTorch ();
		animator.enabled = true;
	}

	public void TakeChalice() {
		Destroy (objectDestory);
		objectToTake.SetActive (true);
	}
}
