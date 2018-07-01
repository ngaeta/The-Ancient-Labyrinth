using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectsPickable : MonoBehaviour, ObjectInteraction {

	public static AudioSource audioSource2D;
	public AudioClip clipOnClick;

	#region ObjectInteraction implementation

	void Start () {
		audioSource2D = GameObject.FindGameObjectWithTag("Audio2DPick").GetComponent<AudioSource>();
	}

	public void OnClick ()
	{
		audioSource2D.clip = clipOnClick;
		audioSource2D.Play ();
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion
}

