using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaRigidbody : MonoBehaviour {

	public float force = 5f;
	private Rigidbody m_RigidBody;

	// Use this for initialization
	void Start () {
		m_RigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		m_RigidBody.AddRelativeForce (transform.right * force, ForceMode.Acceleration);
	}
}
