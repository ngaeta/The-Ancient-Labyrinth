using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCaveInteraction : MonoBehaviour, ObjectInteraction {

	public DoorCaveController doorCaveController;
	public delegate void OnTimerDelayed ();
	public static event OnTimerDelayed timerDelayedEvent;
	public AudioButtonCaveInteraction audioButton;

	private bool m_AlreadyPressed = false;
		
	public  void OnClick() {
		if (!m_AlreadyPressed) {
			m_AlreadyPressed = true;
			audioButton.PlayAudioPressed ();
			if (!doorCaveController.ButtonCavePressed (this))
				ButtonRelease ();
		}
	}

	public void ButtonRelease() {
		audioButton.PlayAudioReleased ();
		m_AlreadyPressed = false;
		timerDelayedEvent ();
	}

	public  void OnRelease ()
	{

	}

	public void OnHeld ()
	{
		
	}
}
