using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSymbolEnigma : MonoBehaviour, ObjectInteraction {

	public AudioClip clipPressed, clipReleased;

	private AudioSource m_AudioSource;
	private bool m_Pressed;

	// Use this for initialization
	void Start () {
		m_Pressed = false;
		m_AudioSource = GetComponent<AudioSource> ();
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		AudioClip clipToPlay;
		if (!m_Pressed)
			clipToPlay = clipPressed;
		else
			clipToPlay = clipReleased;
		m_Pressed = !m_Pressed;
		m_AudioSource.clip = clipToPlay;
		m_AudioSource.Play ();
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion
}
