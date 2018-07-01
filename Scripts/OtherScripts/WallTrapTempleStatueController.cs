using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrapTempleStatueController : MonoBehaviour {

	private Animator m_Animator;

	public AudioSource waterAudioSource;
	public string TriggerNameCloseDoor = "Close";

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
	}
	
	public void CloseDoor() {
		m_Animator.SetTrigger (TriggerNameCloseDoor);
	}

	public void PlayWaterAudio() {
		waterAudioSource.Play ();
	}
}
