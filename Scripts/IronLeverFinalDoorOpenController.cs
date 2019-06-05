using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronLeverFinalDoorOpenController : IronLeverBaseInteraction {

	public FinalDoorController door;

	#region implemented abstract members of IronLeverBaseInteraction

	public override void OnLeverDown ()
	{
		
	}

	public override void OnFinishLeverAnimation ()
	{
		door.OpenDoor ();
		Destroy (this);
	}

	#endregion
}
