using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiSarcophagusInteraction : MonoBehaviour, ObjectInteraction {

	private bool m_SarcophagusUnlocked;
	private Rigidbody m_RigidBody;

	public float force;

	// Use this for initialization
	void Start () {
		m_RigidBody = transform.parent.GetComponent<Rigidbody> ();
		m_SarcophagusUnlocked = false;
		AnubiSarcophagusEnigma.OnEnigmaResolved += UnlockDoor;
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
		if (m_SarcophagusUnlocked) {
			m_RigidBody.AddForce (-transform.forward * force);
		}
	}

	#endregion

	public void UnlockDoor() {
		m_SarcophagusUnlocked = true;
	}

	void Enable() {
		AnubiSarcophagusEnigma.OnEnigmaResolved += UnlockDoor;
	}

	void Disable() {
		AnubiSarcophagusEnigma.OnEnigmaResolved -= UnlockDoor;
	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Terrain")) {
			if (m_RigidBody.velocity.sqrMagnitude < 0.5f) {
				Destroy (m_RigidBody);
				Destroy (this);
			}
		}
	}
}
