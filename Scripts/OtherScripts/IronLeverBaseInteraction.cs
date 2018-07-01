using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IronLeverBaseInteraction: MonoBehaviour, ObjectInteraction {

	private Animator m_Animator;
	protected bool m_IsLocked;

	public AudioSource audio2D;
	public AudioClip clipLever;
	public bool debugOpen = false;

	void Start () {
		OnStart ();
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		ClickAction ();
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion

	protected void ClickAction() {
		if (!m_IsLocked) {
			m_IsLocked = true;
			audio2D.clip = clipLever;
			audio2D.Play ();
			m_Animator.enabled = true;
			OnLeverDown ();
		}
	}

	public bool IsLocked {
		set {
			m_IsLocked = value;
		}
	}

	protected void OnStart() {
		m_Animator = GetComponent<Animator> ();
		m_IsLocked = true;
		if (debugOpen)
			m_IsLocked = false;
	}

	//will be called when the player will click on the lever
	public abstract void OnLeverDown();

	//will be called whent the animation lever will be finished
	public abstract void OnFinishLeverAnimation ();
}
