using UnityEngine;
using System.Collections;

public class AudioVoiceMonster : MonoBehaviour {

	private AudioSource m_AudioSource;

	public float[] nextRoarRate; 
	public AudioClip clipRoar, clipAttack;
	public AudioClip[] clipsGrrr;
	public float maxDistanceRoar = 50f, minDistanceRoar = 45f;
	public float maxDistanceGrrr = 15f, minDistanceGrrr = 30f;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		IAMonsterController.OnRoarEvent += AlertMonster;
		IAMonsterController.OnLookAroundEvent += IdleMonster;
		IAMonsterController.OnAttackEvent += AudioAttack;
		//m_NextRoar = Time.time + nextRoarRate [Random.Range(0, nextRoarRate.Length - 1)];
		float timeToNextRoar = nextRoarRate[Random.Range(0, nextRoarRate.Length)];
		Invoke("PlayGrrr", timeToNextRoar);
	}

	void OnDisable() {
		IAMonsterController.OnRoarEvent -= AlertMonster;
		IAMonsterController.OnLookAroundEvent -= IdleMonster;
		IAMonsterController.OnAttackEvent -= AudioAttack;
	}

	public void AlertMonster (Transform target) {
		m_AudioSource.clip = clipRoar;
	}

	public void WalkMonster () {}

	public void IdleMonster() {
		CancelInvoke ();
		PlayGrrr ();
	}

	public void RunMonster() {
		
	}

	public void SearchPlayerMonster () {
	}

	public void Play() {
		m_AudioSource.clip = clipRoar;
		m_AudioSource.maxDistance = maxDistanceRoar;
		m_AudioSource.minDistance = minDistanceRoar;
		m_AudioSource.Play ();
	}

	private void PlayGrrr() {
		if (!m_AudioSource.isPlaying) {
			m_AudioSource.maxDistance = maxDistanceGrrr;
			m_AudioSource.minDistance = minDistanceGrrr;
			int random_Grrr = Random.Range (0, clipsGrrr.Length);
			m_AudioSource.clip = clipsGrrr [random_Grrr];
			m_AudioSource.Play ();
		} 
		float timeToNextRoar = nextRoarRate [Random.Range (0, nextRoarRate.Length)];
		Invoke ("PlayGrrr", timeToNextRoar);
	}

	public void AudioAttack(Transform t) {
		m_AudioSource.clip = clipAttack;
		m_AudioSource.Play ();
	}
}
