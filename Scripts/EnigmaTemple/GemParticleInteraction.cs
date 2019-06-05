using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemParticleInteraction : MonoBehaviour {

	public GameObject particle;

	public void SwitchParticle(bool value) {
		particle.SetActive (value);
	}
}
