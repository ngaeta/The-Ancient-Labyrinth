using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTorch : MonoBehaviour, ObjectInteraction {

	public InputController input;
	public GameObject torchPlayerToActive;
	public GameObject torchToDestroy;
	public Animator[] doorsAnimator;
	public GearController gears;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		Destroy (torchToDestroy);
		torchPlayerToActive.SetActive (true);
		input.TorchPicked ();
		ActiveDoors ();
		Destroy (this);
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion

	private void ActiveDoors() {
		gears.ActiveGear (false);
		foreach (Animator a in doorsAnimator)
			a.enabled = true;
	}
}
