using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

	private Animator m_Animator;
	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_Animator= GetComponent<Animator> ();
		m_AudioSource = GetComponent<AudioSource> ();
	}
	
	public void Attack() {
		m_AudioSource.Play ();
		m_Animator.enabled = true;
	}
}
