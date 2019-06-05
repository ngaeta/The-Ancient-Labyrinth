using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertSphereInteraction : ObjectInventoryInteraction {

	public PanelLeverPrisonController[] panelLever;

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if(ControlObjectUsed (objectUsed)) {
			GetComponent<MeshRenderer> ().enabled = true;
			gameObject.layer = LayerMask.NameToLayer ("Default");
			(GetComponent ("Halo") as Behaviour).enabled = false;
			PlayAudio ();
			AddSpherePanelLever (objectUsed);
			InventoryPlayer.Remove (objectUsed);
			Destroy (objectUsed);
			Destroy (this);
		} else
			Debug.Log ("non va bene");
	}

	#endregion

	private void AddSpherePanelLever(PickObjectInteraction sphere) {
		foreach (PanelLeverPrisonController p in panelLever)
			p.SphereAdded (sphere);
	}
}
