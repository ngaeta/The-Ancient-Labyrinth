using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceptreCrowEnigmaInteraction : ObjectInventoryInteraction {

	public GameObject sceptreToActive;
	public Animator eyeLeft, eyeRight;
	public AudioSource audioEyeToPlay;
	public GearController gears;
	public CylinderController cylinder;
	public float delayToActiveMechanismAfterClip = 1.5f;
	public AudioSource audioUnlock;

	private Animator m_AnimatorHand;

	void Start() {
		m_AnimatorHand = GetComponent<Animator> ();
	}

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if (ControlObjectUsed (objectUsed)) {
			PlayAudio ();
			InventoryPlayer.Remove (objectUsed);
			gameObject.layer = LayerMask.NameToLayer ("IgnoreAll");
			sceptreToActive.SetActive (true);
			m_AnimatorHand.enabled = true;
			Destroy (objectUsed);
		}
	}

	#endregion

	public void OnAnimationHandFinish() {
		audioUnlock.Play ();
		eyeLeft.enabled = true;
		eyeRight.enabled = true;
		audioEyeToPlay.Play ();
		Invoke ("ActiveMechanism", audioEyeToPlay.clip.length + delayToActiveMechanismAfterClip);
	}

	private void ActiveMechanism() {
		gears.ActiveGear (false);
		cylinder.Active ();
		Destroy (this);
	}
}
