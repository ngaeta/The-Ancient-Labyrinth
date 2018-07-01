using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnkhEnigmaInteraction : ObjectInventoryInteraction {

	public Inventory inventoryPlayer;
	public string newLayer = "Wall";
	public DoorTempleController door;
	public GameObject objectToActive;

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		Debug.Log ("Pick Ankj");
		if (ControlObjectUsed (objectUsed)) {
			objectToActive.SetActive (true);
			inventoryPlayer.Remove (objectUsed);
			gameObject.layer = LayerMask.NameToLayer (newLayer);
			door.KeyAdded ();
			PlayAudio ();
			Destroy (objectUsed);
			Destroy (this);
		} else
			Debug.Log ("false");
	}

	#endregion
}
