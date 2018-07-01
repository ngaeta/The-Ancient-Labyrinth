using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {

	private Animator m_Animator;
	public GameObject torchInteraction;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
	}

	public void Active() {
		m_Animator.enabled = true;
	}

	public void ActiveTorchInteraction() {
		torchInteraction.layer = LayerMask.NameToLayer ("PlayerInteraction");
		Destroy (this);
	}
}
