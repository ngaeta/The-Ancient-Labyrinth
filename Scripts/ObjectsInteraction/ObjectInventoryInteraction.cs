using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectInventoryInteraction : MonoBehaviour {

	public PickObjectInteraction[] objectNeeded;
	public Inventory InventoryPlayer;
	public AudioSource audioInteraction2D;
	public AudioClip clipAudio;

	public abstract void UseObject (PickObjectInteraction objectUsed);

	protected virtual bool ControlObjectUsed(PickObjectInteraction objectUsed) {
		foreach (PickObjectInteraction p in objectNeeded)
			if (p!=null && p == objectUsed) 
				return true;
		return false;
	}

	protected virtual void PlayAudio() {
		audioInteraction2D.clip = clipAudio;
		audioInteraction2D.Play ();
	}
}
