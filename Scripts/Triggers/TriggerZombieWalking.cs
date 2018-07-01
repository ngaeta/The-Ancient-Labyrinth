using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombieWalking : MonoBehaviour {

	public ZombieMummyController zombie;
	public GameMusicScript gameMusic;
	public AudioClip clipMusicZombie;
	public GameObject triggerTrap;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			zombie.Walk ();
			zombie.NextRoar ();
			gameMusic.ChangeMusicAndPlay (clipMusicZombie);
			triggerTrap.SetActive (true);
			Destroy (gameObject);
		}
	}
}
