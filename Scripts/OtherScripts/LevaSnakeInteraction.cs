using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevaSnakeInteraction : ObjectInventoryInteraction {

	public GameObject sceptreToActive;
	public Inventory inventoryPlayer;
	public static AudioSource audioSource2D;
	public AudioClip clipOnClick;

	void Start() {
		audioSource2D = GameObject.FindGameObjectWithTag("Audio2DPick").GetComponent<AudioSource>();
	}

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if(ControlObjectUsed (objectUsed)) {
			audioSource2D.clip = clipOnClick;
			audioSource2D.Play ();
       		inventoryPlayer.Remove (objectUsed);
			sceptreToActive.SetActive (true);
			Destroy (objectUsed);
			Destroy (gameObject);
		}
	}

	#endregion
}
