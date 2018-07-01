using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBalanceController : MonoBehaviour {

	private Animator m_Animator;
	public string TriggerGoodBalance = "Good";
	public string TriggerEvilBalance = "Evil";
	public GameObject paradisePortal, infernoPortal;
	public GameManager gameManager;
	public int numberSoulSaveToParadise = 3;
	private AudioSource m_AudioSource;
	private bool m_Paradise;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_AudioSource = GetComponent<AudioSource> ();
		m_Paradise = false;
	}
	
	public void ControlBalance() {
		if (gameManager.GetSoulsSaved >= numberSoulSaveToParadise) {
			m_Paradise = true;
			m_Animator.SetTrigger (TriggerGoodBalance);
		} else {
			m_Paradise = false;
			m_Animator.SetTrigger (TriggerEvilBalance);
		}
		m_AudioSource.Play ();
	}

	public void ActivePortal() {
		if (m_Paradise)
			paradisePortal.SetActive (true);
		else
			infernoPortal.SetActive (true);
	}
}
