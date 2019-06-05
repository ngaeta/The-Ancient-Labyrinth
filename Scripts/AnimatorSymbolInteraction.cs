using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSymbolInteraction : MonoBehaviour, ObjectInteraction {

	public string triggerReleasedAnim = "Released";
	public string triggerPressedAnim = "Clicked";

	public float nextClick = 0.5f;
	private bool m_NextClick;
	private bool m_Pressed;
	private Animator m_Animator;
	private int m_HashTriggerPressed;
	private int m_HashTriggerRelease;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_HashTriggerPressed = Animator.StringToHash (triggerPressedAnim);
		m_HashTriggerRelease = Animator.StringToHash (triggerReleasedAnim);
		m_Pressed = false;
		m_NextClick = true;
	}

	private IEnumerator WaitNextClick() {
		yield return new WaitForSecondsRealtime (nextClick);
		m_NextClick = true;
	}
	

	#region ObjectInteraction implementation
	public void OnClick ()
	{
		if (m_NextClick) {
			m_NextClick = false;
			if (!m_Pressed)
				m_Animator.SetTrigger (m_HashTriggerPressed);
			else
				m_Animator.SetTrigger (m_HashTriggerRelease);

			m_Pressed = !m_Pressed;
			StartCoroutine (WaitNextClick ());
		}
	}

	public void OnRelease ()
	{

	}
	public void OnHeld ()
	{
		
	}
	#endregion
}
