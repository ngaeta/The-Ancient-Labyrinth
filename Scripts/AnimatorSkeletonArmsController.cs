using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSkeletonArmsController : MonoBehaviour {

	private Animator m_Animator;
	private int m_hashTriggerDown;

	public string nameTriggerDown = "Down";
	public PickObjectInteraction pickObject;

	void Start () {
		m_Animator = GetComponent<Animator> ();
		pickObject.OnPickObject +=	DownAnimation;
		m_hashTriggerDown = Animator.StringToHash (nameTriggerDown);
	}

	void OnDisable() {
		pickObject.OnPickObject -=	DownAnimation;
	}

	void OnEnable() {
		pickObject.OnPickObject += DownAnimation;
	}

	public void DownAnimation() {
		m_Animator.SetTrigger (m_hashTriggerDown);
	}
}
