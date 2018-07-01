using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

	private Animator m_Animator;
	public string triggerNameRun = "Run";
	private ScorpionMovingController moving;
	public float timeToDestroy = 7f;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		moving = GetComponent<ScorpionMovingController> ();
	}

	public void RunSpider() {
		m_Animator.SetTrigger (triggerNameRun);
		moving.enabled = true;
		Destroy (gameObject, timeToDestroy);
	}
}
