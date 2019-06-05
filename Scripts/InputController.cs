using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour {


	public MouseCursor mouseCursorScript;
	public GameObject torch;
	public float nextInput = 1f;
	public TorchController torchController;

	private bool m_HeldInteraction;
	private bool m_NextInput = true;
	private bool m_PlayerHasTorch;

	private ObjectInteraction[] lastObject = null;

	void Start() {
		m_PlayerHasTorch = false;
		m_HeldInteraction = false;
		MouseCursor.OnScriptDisabledEvent += LastObjectNull;
	}

	void FixedUpdate() {
		
		if (Input.GetMouseButtonDown (0)) {
			GameObject objectInteraction = mouseCursorScript.OverObject;
			if (objectInteraction != null) {
				ObjectInteraction[] interactions = objectInteraction.GetComponents<ObjectInteraction> ();
				if (interactions.Length > 0) {
					lastObject = interactions;
					clickInteraction ();
				}
			} 
		} else if (Input.GetMouseButtonUp (0)) {
			if (lastObject != null) {
				m_HeldInteraction = false;
				releaseInteraction ();
			}
		} else if (Input.GetMouseButton (0)) {
			GameObject objectInteraction = mouseCursorScript.OverObject;
			if (objectInteraction != null && lastObject != null) {
				m_HeldInteraction = true;
				heldInteraction ();
			}
		} else if (Input.GetButton ("Torch") && m_PlayerHasTorch && m_NextInput) {
			m_NextInput = false;
			torchController.SwitchTorch ();
			StartCoroutine (WaitNextInput());
		}
		
			
	}

	private void clickInteraction() {
		foreach (ObjectInteraction interaction in lastObject)
			interaction.OnClick ();
	}

	private void releaseInteraction() {
		foreach (ObjectInteraction interaction in lastObject)
			interaction.OnRelease ();
	}

	public void heldInteraction() {
	
		foreach (ObjectInteraction interaction in lastObject)
			interaction.OnHeld();
	}
	private IEnumerator WaitNextInput() {
		yield return new WaitForSeconds (nextInput);
		m_NextInput = true;
	}

	public void LastObjectNull() {
		if (m_HeldInteraction && lastObject != null) {
			releaseInteraction ();
			lastObject = null;
		}
	}

	public void TorchPicked() {
		m_PlayerHasTorch = true;
	}
}
