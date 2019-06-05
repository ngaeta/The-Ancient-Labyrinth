using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummySarcophagusController : MonoBehaviour {

	private Animator m_Animator;
	public AudioSource MovementAudioSource;
	public AudioSource ScreamAudioSource;
	private int m_HashTrigger;

	public string TriggerNameAnimation = "Move";

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_HashTrigger = Animator.StringToHash (TriggerNameAnimation);
	}
	
	public void PlayAnimationMoving() {
		MovementAudioSource.Play ();
		m_Animator.SetTrigger (m_HashTrigger);
	}

	public void PlayScream() {
		if(!ScreamAudioSource.isPlaying)
			ScreamAudioSource.Play ();
	}
}
