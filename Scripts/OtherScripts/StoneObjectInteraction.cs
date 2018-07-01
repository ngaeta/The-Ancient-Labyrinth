using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneObjectInteraction : MonoBehaviour, ObjectInteraction {

	public GameObject keyHidden; 

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		keyHidden.SetActive (true);
		Destroy (gameObject);
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion
}
