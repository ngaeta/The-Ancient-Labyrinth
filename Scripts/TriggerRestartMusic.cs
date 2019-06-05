using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRestartMusic : MonoBehaviour {

	public GameMusicScript ScriptMusic;
	public AudioClip newMusic;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			ScriptMusic.Stopped = false;
			ScriptMusic.ChangeMusicAndPlay (newMusic);
		}
	}
}
