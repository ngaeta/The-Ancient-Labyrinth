using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseInteraction : MonoBehaviour, ObjectInteraction {


	private Rigidbody m_RigidBody;
	public float force = 2f;

	void Start() {
		m_RigidBody = GetComponentInParent<Rigidbody> ();
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		if(m_RigidBody!=null)
			m_RigidBody.AddForce (-transform.forward  * force);	
	}

	#endregion
}
