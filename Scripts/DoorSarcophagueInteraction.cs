using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSarcophagueInteraction : MonoBehaviour, ObjectInteraction {

	public delegate void ClickAction();
	public static event ClickAction clickEvent;

	public  void OnClick ()
	{
		TriggerSarcophagueEnigma.PlayerTouchedSarcophague ();
		clickEvent ();
	}

	public  void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}
}
