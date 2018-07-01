using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioThunderController : MonoBehaviour {

	public AudioClip firstClip;
	public AudioClip[] thunders;
	public float[] rangeThunders;

	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		m_AudioSource.clip = firstClip;
		m_AudioSource.Play ();
		Invoke ("PlayThunder", rangeThunders [Random.Range (0, rangeThunders.Length)]);
	}

	private void PlayThunder() {
		if (!m_AudioSource.isPlaying) {
			AudioClip clipThunder = thunders [Random.Range (0, thunders.Length)];
			m_AudioSource.clip = clipThunder;
			m_AudioSource.Play ();
		}

		Invoke ("PlayThunder", rangeThunders[Random.Range (0, rangeThunders.Length)]);
	}
}
