using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHellController : MonoBehaviour {

	public GameObject lavaFalling;
	public AudioSource audioVoice;
	public delegate void AnimationEnd ();
	public event AnimationEnd OnAnimationEndEvent;
	public float timeToWaitToStartVoice = 2f;
	public AudioClip clipLaugh;
	public AudioClip clipVoice;


	private Animator m_Animator;

	void Start() {
		m_Animator = GetComponent<Animator> ();
	}

	public void PlayLavaFalling() {
		lavaFalling.SetActive (true);
	}

	public void AnimationFinished() {
		if (OnAnimationEndEvent != null)
			OnAnimationEndEvent ();
		StartCoroutine (WaitToPlayVoice ());
	}

	public void StartAnimation() {
		m_Animator.enabled = true;
	}

	public float getLenghtClipAudio() {
		return clipVoice.length;
	}

	public void PlayLaugh() {
		audioVoice.clip = clipLaugh;
		audioVoice.Play ();
	}

	private IEnumerator WaitToPlayVoice() {
		yield return new WaitForSecondsRealtime (timeToWaitToStartVoice);
		audioVoice.clip = clipVoice;
		audioVoice.Play ();
	}
}
