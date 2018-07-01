using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonSoulsContoller : MonoBehaviour {

	private Animator m_Animator;
	private AudioSource m_AudioSource;

	public delegate void OnPrisonFullOpened();
	public event OnPrisonFullOpened onPrisonFullOpenedEvent;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_AudioSource = GetComponent<AudioSource> ();
	}
	
	public void OpenCage() {
		m_Animator.enabled = true;
		m_AudioSource.Play ();
	}

	public void PrisonFullOpened() {
		if (onPrisonFullOpenedEvent != null)
			onPrisonFullOpenedEvent ();
	}
}
