using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveSandDoor : MonoBehaviour {

	public ParticleSystem particle;

	public void Active() {
		particle.Play ();
	}

	public void Deactive() {
		ParticleSystem.MainModule mainModule = particle.main;
		mainModule.loop = false;
	}
}
