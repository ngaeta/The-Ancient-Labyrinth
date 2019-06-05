using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {

	private Rigidbody m_Rigid;
	public float force = 2f;

	// Use this for initialization
	void Awake () {
		m_Rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		m_Rigid.AddRelativeForce ((-transform.forward + transform.up) * force);
	}
		
}
