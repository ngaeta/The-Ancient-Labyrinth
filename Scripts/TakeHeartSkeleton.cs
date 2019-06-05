using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHeartSkeleton : MonoBehaviour {

	private Animator m_Animator;

	public GameObject heartToTake;

	void Start() {
		m_Animator = GetComponent<Animator> ();
		RitualEnigmaInteraction.OnObjectPositioned += PlayAnimation;
	}

	void OnDisable() {
		RitualEnigmaInteraction.OnObjectPositioned -= PlayAnimation;
	}

	public void PlayAnimation() {
		m_Animator.enabled = true;
	}

	public void TakeHeart() {
		heartToTake.transform.parent = this.transform;
		Destroy (gameObject, 3f);
	}
}
