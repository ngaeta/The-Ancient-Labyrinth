using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioPlay : MonoBehaviour {

	public AudioSource audioToPlay;
	public GameMusicScript gameMusic;

	public float newVolumeMusic = 1f;
	public AudioClip newMusic;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			audioToPlay.Play ();
			gameMusic.ChangeMusicAndPlay (newMusic);
			gameMusic.ChangeVolume (newVolumeMusic);
			Destroy (this);
		}
	}
}
