using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemParticleInteraction : MonoBehaviour {

	public GameObject particle;


	public void SwitchParticle() {
		particle.SetActive (!particle.activeInHierarchy);
	}
}
