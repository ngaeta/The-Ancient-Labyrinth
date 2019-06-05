using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinalChoiceInteraction: PickObjectInteraction {

	public GameObject barrerToDisactive;

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		barrerToDisactive.SetActive (false);
		base.OnClick ();
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion
}
