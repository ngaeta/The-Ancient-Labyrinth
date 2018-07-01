using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronLeverPrisonSoulsInteraction : IronLeverBaseInteraction{

	public PrisonSoulsContoller prison;
	public GameManager gameManager;

	#region implemented abstract members of IronLeverBaseInteraction
	public override void OnLeverDown ()
	{
		gameManager.SoulsSaved ();
	}


	public override void OnFinishLeverAnimation ()
	{
		prison.OpenCage ();
		Destroy (this);
	}

	#endregion

}
