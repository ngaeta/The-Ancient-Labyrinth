using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCaveController : MonoBehaviour {

	private int m_NextButtonToPressed = 0;
	private int m_ActualTimeCountdown = 0;

	public delegate void DoorOpened ();
	public static event DoorOpened OnDoorOpenedEvent;
	public int timeCountdown = 15;
	public ButtonCaveInteraction[] buttonCaveOrderToPush;
	public AudioTimer audioTimer;
	public AudioDoorCave audio;
    public bool OpenDebug;

    void Start()
    {
        if(OpenDebug)
        {
            BroadcastMessage("Open");
            if (OnDoorOpenedEvent != null)
                OnDoorOpenedEvent();
        }
    }

	public bool ButtonCavePressed(ButtonCaveInteraction buttonPressed) {
	
		if (buttonPressed == buttonCaveOrderToPush [m_NextButtonToPressed]) {
			if (m_NextButtonToPressed == 0) {
				audioTimer.Play ();
				StartCoroutine ("StartCountDown");
			}

			m_NextButtonToPressed++;
			if (m_NextButtonToPressed == buttonCaveOrderToPush.Length) {
				StopCoroutine ("StartCountDown");
				audioTimer.Stop ();
				BroadcastMessage ("Open");
				if (OnDoorOpenedEvent != null)
					OnDoorOpenedEvent ();
			}
			return true;
		}
		else {
			audioTimer.Stop ();
			StopCoroutine ("StartCountDown");
			m_NextButtonToPressed = 0;
			ReleaseAllButton ();
			return false;
		}
	}

	public void ReleaseAllButton() {
		foreach (ButtonCaveInteraction button in buttonCaveOrderToPush)
			button.ButtonRelease();
	}

	private IEnumerator StartCountDown() {
		Debug.Log ("Timer PArtito");
		while (m_ActualTimeCountdown < timeCountdown) {
			yield return new WaitForSecondsRealtime (1f);
			m_ActualTimeCountdown++;
			Debug.Log ("Secondi passati " + m_ActualTimeCountdown);
		}
			
		Debug.Log ("Tempo scaduto");
		audioTimer.Stop ();
		m_NextButtonToPressed = 0;
		m_ActualTimeCountdown = 0;
		ReleaseAllButton ();
	}

	public void Close() {
		audio.Close ();
	}
}
