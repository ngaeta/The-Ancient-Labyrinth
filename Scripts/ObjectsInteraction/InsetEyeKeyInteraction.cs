using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsetEyeKeyInteraction : ObjectInventoryInteraction {

	public GameObject EyeKeyToActive;
	public AudioSource audioToPlay;
	public Animator eyeLeft, eyeRight;
	public GearController gears;
	public CylinderController cylinder;
	public float delayToActiveMechanismAfterClip = 1.5f;
	public Inventory inventoryScript;

	public AudioSource audio2D;
	public AudioClip clip;

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if(ControlObjectUsed (objectUsed)) {
			audio2D.clip = clip;
			inventoryScript.Remove (objectUsed);
			gameObject.layer = LayerMask.NameToLayer ("IgnoreAll");
			EyeKeyToActive.SetActive (true);
			audio2D.Play ();
			eyeLeft.enabled = true;
			eyeRight.enabled = true;
			audioToPlay.Play ();
			Invoke ("ActiveMechanism", audioToPlay.clip.length + delayToActiveMechanismAfterClip);	
			Destroy (objectUsed);
		} else
			Debug.Log ("Diverso");
	}

	#endregion


	private void ActiveMechanism() {
		gears.ActiveGear (false);
		cylinder.Active ();
		Destroy (this);
	}

}
