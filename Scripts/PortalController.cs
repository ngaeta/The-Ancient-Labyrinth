using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

	public CutsceneHellAndParadiseStandUp cutscene;
	public ParticleSystem[] particle;
	public AudioSource audioPortal;
	public AudioClip clipAudioPortalClose;
	public float timeToDeactiveAudio = 5f;

	// Use this for initialization
	void Start () {
		cutscene.OnAnimationHalfTimeEvent += DeactivePortal;
	}

	void OnDisable() {
		cutscene.OnAnimationHalfTimeEvent-= DeactivePortal;
	}

	private void DeactivePortal() {
		foreach (ParticleSystem p in particle) {
			ParticleSystem.MainModule main = p.main;
			main.loop = false;
		}
		Invoke ("DeactiveAudio", timeToDeactiveAudio);
	}

	private void DeactiveAudio() {
		audioPortal.Stop ();
	}

}
