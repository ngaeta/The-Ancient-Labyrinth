using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCaveDoor : MonoBehaviour, DoorInterface {

	private Animator m_Animator;

	void Awake () {
		m_Animator = GetComponent<Animator> ();
	}

	public void Open() {
		m_Animator.enabled = true;
	}

	public void Close() {}
}
