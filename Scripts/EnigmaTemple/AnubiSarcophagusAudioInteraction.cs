using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiSarcophagusAudioInteraction : MonoBehaviour, ObjectInteraction {

	public AudioSource audioSarcophagus;
	public AudioClip openSarcophagus, clipOnGround;
	public GameObject sphere;
	private bool m_DoorIsOpen;

	void Start() {
		m_DoorIsOpen = false;
		AnubiSarcophagusEnigma.OnEnigmaResolved += DoorOpened;
	}

	#region ObjectInteraction implementation
	public void OnClick ()
	{
		
	}
	public void OnRelease ()
	{
		if (m_DoorIsOpen) {
			audioSarcophagus.Stop ();
			Debug.Log (transform.parent.localPosition.z);
			if (transform.parent.localPosition.z > 0.12f)
				sphere.layer = LayerMask.NameToLayer ("PlayerInteraction");
		}
	}
	public void OnHeld ()
	{
		if (m_DoorIsOpen && !audioSarcophagus.isPlaying) {
			audioSarcophagus.clip = openSarcophagus;
			audioSarcophagus.Play ();
		}
	}
	#endregion

	public void DoorOpened() {
		m_DoorIsOpen = true;
	}

	void Enable() {
		AnubiSarcophagusEnigma.OnEnigmaResolved += DoorOpened;
	}

	void Disable() {
		AnubiSarcophagusEnigma.OnEnigmaResolved += DoorOpened;
	}


	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Terrain")) {
			audioSarcophagus.clip = clipOnGround;
			audioSarcophagus.Play ();
		}
	}
}
