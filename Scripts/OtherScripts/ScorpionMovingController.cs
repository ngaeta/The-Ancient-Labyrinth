using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionMovingController : MonoBehaviour {
	public float force = 5f;
	private Rigidbody m_RigidBody;

	// Use this for initialization
	void Start () {
		m_RigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Mathf.Abs(m_RigidBody.velocity.x) < 1.2f)
			m_RigidBody.AddRelativeForce (transform.right * force);
	}
}
