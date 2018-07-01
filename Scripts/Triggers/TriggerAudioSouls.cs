using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioSouls : MonoBehaviour {

	private AudioSource m_AudioSource;
	public AudioClip[] clipSouls;
	public float[] rangeBetweenAudio;

	private int m_NextClip;
	private bool m_CanNext;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		m_NextClip = 0;
		m_CanNext = true;
	}

	void OnTriggerStay(Collider collider) {
		if (m_CanNext && collider.CompareTag ("Player")) {
			m_CanNext = false;
			m_AudioSource.clip = clipSouls [m_NextClip];
			m_AudioSource.Play ();
			m_NextClip = (m_NextClip + 1) % clipSouls.Length;
			StartCoroutine (WaitToNextClip ());
		}
	}

	private IEnumerator WaitToNextClip() {
		int nextTime = Random.Range (0, rangeBetweenAudio.Length);
		yield return new WaitForSecondsRealtime (m_AudioSource.clip.length + rangeBetweenAudio[nextTime]);
		m_CanNext = true;
	}
}
