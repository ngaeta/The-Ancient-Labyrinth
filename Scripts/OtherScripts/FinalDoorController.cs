using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour {

	private Animator m_Animator;
	public string triggerNameOpen = "Open";
	public string triggerNameClosed = "Close";
	private bool m_DoorIsClosed;
	public delegate void DoorClosed ();
	public static event DoorClosed onDoorClosed;
	public bool DebugOpen = false;

	void Start() {
		m_Animator = GetComponent<Animator> ();
		m_DoorIsClosed = true;
		if(DebugOpen)
			OpenDoor ();
	}

	public void OpenDoor() {
		m_DoorIsClosed = false;
		m_Animator.SetTrigger (triggerNameOpen);
	}

	public void CloseDoor() {
		m_DoorIsClosed = true;
		m_Animator.SetTrigger (triggerNameClosed);
	}

	public void DoorClose() {
		if (onDoorClosed != null)
			onDoorClosed ();
	}

	public bool IsDoorClosed {
		get {
			return m_DoorIsClosed;
		}
	}
}
