using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFountainInventoryInteraction : ObjectInventoryInteraction {

    public string newTextChalice = "Full Chalice";

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if (ControlObjectUsed (objectUsed)) {
			ChalicePickInteraction chalice = objectUsed.GetComponent<ChalicePickInteraction> ();
            if (chalice != null)
            {
                chalice.IsEmpty = false;
                objectUsed.ChangeTextObject(newTextChalice);
            }
			gameObject.layer = LayerMask.NameToLayer ("Default");
			PlayAudio ();
			Destroy (this);
		}
	}

	#endregion
}
