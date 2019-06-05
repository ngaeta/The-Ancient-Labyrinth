using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronFenceController : MonoBehaviour {

	private Animator m_Animator;
	private AudioSource m_AudioSource;
	public float timeToDestroyIt = 6f;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_AudioSource = GetComponent<AudioSource> ();
	}
	
	public void LoverFence() {
		m_Animator.enabled = true;
		m_AudioSource.Play ();
		Destroy (gameObject, timeToDestroyIt);
	}
}
