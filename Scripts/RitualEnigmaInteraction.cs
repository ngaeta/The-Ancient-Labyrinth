using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualEnigmaInteraction : ObjectInventoryInteraction {

	public Inventory inventoryPlayer;
	public PickObjectInteraction heartNeeded;
	public GameObject heartToActive;
	public delegate void ObjectPositionedAction ();

	public static event ObjectPositionedAction OnObjectPositioned; 

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if(ControlObjectUsed (objectUsed)) {
			inventoryPlayer.Remove (heartNeeded);
			heartToActive.SetActive (true);
			if (OnObjectPositioned != null)
				OnObjectPositioned ();		
			Destroy (objectUsed);
			Destroy (gameObject);
		}
	}

	#endregion
}
