using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundPassage : MonoBehaviour {

	public AudioClip[] clipsGhost;
	public AudioClip firstClip, lastClipBeforeDestroyTrigger;
	public float[] timeToNextWhispers;
	public float timeToDestroy = 8f;

	private AudioClip m_NextClipGhost;
	private bool m_CanPlay;
	private AudioSource m_AudioSource;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		m_NextClipGhost= firstClip;
		m_CanPlay = true;
	}

	void OnTriggerStay(Collider collider) {
		if (m_CanPlay && collider.gameObject.CompareTag ("Player")) {
			m_CanPlay=false;
			PlayNextClip();
			StartCoroutine (WaitToNextWhispers(timeToNextWhispers [Random.Range (0, timeToNextWhispers.Length)]));
		}
	}

	private void PlayNextClip() {
		if (!m_AudioSource.isPlaying) {
			m_AudioSource.clip = m_NextClipGhost;
			m_AudioSource.Play ();
			m_NextClipGhost = clipsGhost [Random.Range (0, clipsGhost.Length)];
		}
	}

	private IEnumerator WaitToNextWhispers(float timeToWhispers) {
		yield return new WaitForSecondsRealtime (timeToWhispers);
		m_CanPlay = true;
	}

	public void PlayClipAndDestoryItSelf() {
		StopAllCoroutines ();
		m_CanPlay = false;
		m_AudioSource.clip = lastClipBeforeDestroyTrigger;
		m_AudioSource.Play ();
		Destroy (gameObject, timeToDestroy);
	}
}
