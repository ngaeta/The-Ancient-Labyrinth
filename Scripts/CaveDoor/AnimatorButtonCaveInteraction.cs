using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorButtonCaveInteraction : MonoBehaviour, ObjectInteraction {

	public string nameTriggerOnReleased = "Released";
	public string nameTriggerOnClicked = "Pressed";

	private int m_HashTriggerReleased, m_HashTriggerPressed;
	private Animator m_Animator;

	void Start() {
		m_Animator = GetComponent<Animator> ();
		m_HashTriggerReleased = Animator.StringToHash (nameTriggerOnReleased);
		m_HashTriggerPressed = Animator.StringToHash (nameTriggerOnClicked);
	}
		
	void OnReleasedAnimation() {
		m_Animator.SetTrigger (m_HashTriggerReleased);
	}

	void OnEnable() {
		ButtonCaveInteraction.timerDelayedEvent += OnReleasedAnimation;
	}

	void OnDisable() {
		ButtonCaveInteraction.timerDelayedEvent -= OnReleasedAnimation;
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		m_Animator.SetTrigger (m_HashTriggerPressed);
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion
}
