using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFinalTempleController : MonoBehaviour, ObjectInteraction {

	public Animator doorAnimator;
	public string triggerOpenAnim = "Open";
	public string triggerCloseAnim = "Close";
	public DoorFinalTempleAudioController audioDoor;


	#region ObjectInteraction implementation
	public void OnClick ()
	{
		audioDoor.PlayAudioDoorOpened ();
		doorAnimator.SetTrigger (triggerOpenAnim);
	}
	public void OnRelease ()
	{
		
	}
	public void OnHeld ()
	{
		
	}
	#endregion

	public void CloseDoor() {
		doorAnimator.SetTrigger (triggerCloseAnim);
	}
}
