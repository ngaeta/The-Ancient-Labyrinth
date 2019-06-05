using UnityEngine;
using System.Collections;

public class AudioWalkMonster : MonoBehaviour {

	private AudioSource m_AudioSource;

	public AudioClip clipWalk;

	void Awake() {
		m_AudioSource = GetComponent<AudioSource> ();
		IAMonsterController.OnWalkEvent += WalkMonster;
		IAMonsterController.OnLookAroundEvent += IdleMonster;
	}
		
	public void WalkMonster(Transform t) {
		while (m_AudioSource == null)
			m_AudioSource = GetComponent<AudioSource> ();
		m_AudioSource.clip = clipWalk;
	}
		
	public void RunMonster() {
		m_AudioSource.clip = clipWalk;
	}

	public void AlertMonster (Transform target) {}

	public void IdleMonster() {
		m_AudioSource.Stop ();
	}

	public void Play() {
		m_AudioSource.Play ();
	}

	void OnDisable() {
		IAMonsterController.OnWalkEvent -= WalkMonster;
		IAMonsterController.OnLookAroundEvent -= IdleMonster;
	}
}
