using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerDead : MonoBehaviour {

	private Animator m_Animator;
	private VignetteAndChromaticAberration scriptVignette;
	public float f=0.1f;
	public AudioSource audioVoice;
	public AudioClip clipDie;
	public GameManager gameManager;
	public UIManager ui;

	void Start() {
		m_Animator = GetComponent<Animator> ();
		scriptVignette = GetComponent<VignetteAndChromaticAberration> ();
	}

	public void Dead() {
		audioVoice.clip = clipDie;
		audioVoice.PlayOneShot (clipDie);
		scriptVignette.enabled = true;
		m_Animator.enabled = true;
	}

	void Update() {
		if (m_Animator.enabled) {
			ui.enabled = false;
			if (scriptVignette.intensity < 0.998f) {
				Debug.Log ("Died scene");
				scriptVignette.intensity = Mathf.Lerp (scriptVignette.intensity, 1f, Time.deltaTime * f);
			}
			else {
				gameManager.LoadSceneDirectly ("GameOver");
			}
		}
	}

	private bool IsEqual(float a, float b) {
		if (a >= b - Mathf.Epsilon && a <= b + Mathf.Epsilon)
			return true;
		else
			return false;
	}

}
