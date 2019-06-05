using UnityEngine;
using System.Collections;

public class GameMusicScript : MonoBehaviour {

	private AudioSource m_AudioSource;
	private bool m_MusicAlertIsPlaying = false;
	private bool m_MusicStopped = false;

	public IAMonsterController IAMonsterController;
	public float volumeDefault = 0.65f;
	public AudioClip musicAlert;
	public AudioClip musicDefault;
	private AudioClip musicToPlay;

	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		musicToPlay = musicDefault;
	}
	
	// Update is called once per frame
	void Update () {
		if (!m_MusicStopped) {
			if (IAMonsterController.monsterState == MonsterAction.MONSTER_ACTION.ROAR && !m_MusicAlertIsPlaying) {
				m_MusicAlertIsPlaying = true;
				m_AudioSource.clip = musicAlert;
				m_AudioSource.volume = 1f;
				m_AudioSource.Play ();
			} else if (m_MusicAlertIsPlaying && IAMonsterController.monsterState == MonsterAction.MONSTER_ACTION.WALK) {
				m_MusicAlertIsPlaying = false;
				m_AudioSource.clip = musicToPlay;
				m_AudioSource.volume = volumeDefault;
				m_AudioSource.Play ();
			}
		}
	}


	public void ChangeMusicAndPlay(AudioClip clipMusic) {
		musicToPlay= clipMusic;
		m_AudioSource.clip = musicToPlay;
		m_AudioSource.Play ();
	}

	public void ChangeMusicDefault(AudioClip newMusicDefault) {
		musicDefault = newMusicDefault;
	}

	public bool Stopped {
		set {
			m_AudioSource.Stop ();
			m_MusicStopped = value;
		}
	}

	public void Stop() {
		m_AudioSource.Stop ();
	}

	public void ChangeVolume(float newVolume) {
		m_AudioSource.volume = newVolume;
	}

	public void Play() {
		if(!m_AudioSource.isPlaying)
			m_AudioSource.Play ();
	}

	public void PlayMusicDefault() {
		musicToPlay = musicDefault;
		m_AudioSource.clip = musicDefault;
		m_AudioSource.Play ();
	}
}
