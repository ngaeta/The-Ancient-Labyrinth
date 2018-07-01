using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSarcophague : MonoBehaviour {

	public float force = 200f;
	public delegate void ExplodeAction ();

	public GameObject heartObject;
	public static event ExplodeAction OnExplode;


	private Rigidbody m_RigidBody;

	void Awake() {
		m_RigidBody = GetComponent<Rigidbody> ();
	}
		
	public void ExplodeDoor() {
		m_RigidBody.isKinematic = false;
		m_RigidBody.useGravity = true;
		m_RigidBody.AddForce (transform.right * force);
		if(OnExplode != null)
			OnExplode ();
		heartObject.layer = LayerMask.NameToLayer ("PlayerInteraction");
		Destroy (this);
	}


}
