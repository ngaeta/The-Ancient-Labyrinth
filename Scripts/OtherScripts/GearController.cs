using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {

	public Animator[] gearAnims;
	public string nameTriggerAnim = "Active";

	private AudioSource m_AudioSource;
	private int m_HashTriggerAnim;

	void Start() {
		m_AudioSource = GetComponent<AudioSource> ();
		m_HashTriggerAnim = Animator.StringToHash (nameTriggerAnim);
	}

	public void ActiveGear(bool loop) {
		m_AudioSource.loop = loop;
		foreach (Animator gear in gearAnims)
			gear.SetTrigger (m_HashTriggerAnim);
		m_AudioSource.Play ();
	}

	public void StopAudio() {
		m_AudioSource.Stop ();
	}
}
