using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZombieMummyController : MonoBehaviour {

	private AudioSource m_AudioSource;
	private AudioClip m_NextClipRoar;

	public AudioClip clipAttack;
	public AudioClip[] clipsRoar;
	public AudioClip firstClip;

	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		m_NextClipRoar = firstClip;
	}

	public void PlayAttack() {
		m_AudioSource.clip = clipAttack;
		m_AudioSource.Play ();
	}

	public void  PlayRoar() {
		if (!m_AudioSource.isPlaying) {
			m_AudioSource.clip = m_NextClipRoar;
			m_AudioSource.Play ();
			m_NextClipRoar = clipsRoar [Random.Range (0, clipsRoar.Length)];
		} 
	}
}
