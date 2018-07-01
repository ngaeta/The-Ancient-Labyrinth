using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceptreLevaInteraction : MonoBehaviour, ObjectInteraction {

	private Animator m_Animator;
	public MeshRenderer eyeLevaSnake;
	public Color colorEye;
	public Animator doorToOpen;
	public AudioReverbFilter audioZombie;

	private Material m_MaterialEye;
	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_AudioSource = GetComponent<AudioSource> ();
		m_MaterialEye = eyeLevaSnake.material;
	}
	

	#region ObjectInteraction implementation
	public void OnClick ()
	{
		audioZombie.enabled = false;
		m_AudioSource.Play ();
		m_Animator.enabled = true;
		m_MaterialEye.color = colorEye;
		m_MaterialEye.SetColor ("_EmissionColor", colorEye);
		doorToOpen.enabled = true;
		Destroy (this);
	}
	public void OnRelease ()
	{
		
	}
	public void OnHeld ()
	{
		
	}
	#endregion
}
