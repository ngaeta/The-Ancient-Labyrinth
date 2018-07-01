using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsController : MonoBehaviour {

	private Animator m_Animator;
	public GameObject triggerAudioSouls;
	public PrisonSoulsContoller prison;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		prison.onPrisonFullOpenedEvent += ActiveAnimation;
	}
	

	public void ActiveAnimation() {
		Destroy (triggerAudioSouls);
		m_Animator.enabled = true;
	}

	void OnDisable() {
		prison.onPrisonFullOpenedEvent -= ActiveAnimation;
	}

	public void DestroyObject() {
		Destroy (gameObject);
	}
}
