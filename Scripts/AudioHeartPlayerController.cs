using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHeartPlayerController : MonoBehaviour {

	public Transform monsterTransform;
	public IAMonsterController ia;

	private AudioSource audioHeart;

	void Start() {
		audioHeart = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (ia.MonsterState == MonsterAction.MONSTER_ACTION.RUN) {
			if(!audioHeart.isPlaying)
				audioHeart.Play ();
			ControlHeartBeat ();
		} 
	}

	private void ControlHeartBeat() {
		float distanceToMonster = Vector3.Distance (transform.position, monsterTransform.position);
		if (distanceToMonster < 5f)
			audioHeart.pitch = 3f;
		else if (distanceToMonster < 10f)
			audioHeart.pitch = 2f;
		else
			audioHeart.pitch = 1f;
	}
}
