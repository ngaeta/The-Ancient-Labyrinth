using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoor : MonoBehaviour {

	public GameObject fireToControl, doorMagic;
	[Range(0, 1)] public float alphaDoor = 0.5f;

	private Collider m_DoorCollider;
	private Material m_DoorMaterial;
	private bool m_IsOpen;

	void Start() {
		m_DoorCollider = doorMagic.GetComponent<Collider> ();
		m_DoorMaterial = doorMagic.GetComponent<MeshRenderer> ().material;
		m_IsOpen = false;
	}

	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			if (fireToControl.activeInHierarchy && m_IsOpen) {
                Debug.Log("Porta chiusa, torcia accesa");
				DoorTrasparentOff ();
			} else if(!fireToControl.activeInHierarchy && !m_IsOpen) {
				Debug.Log ("Porta trasparente");
				m_IsOpen = true;
				m_DoorCollider.isTrigger = true;
				m_DoorMaterial.color = new Color (m_DoorMaterial.color.r, m_DoorMaterial.color.b, m_DoorMaterial.color.g, alphaDoor);
			}
		}
	}

	void OnTriggerExit(Collider collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			DoorTrasparentOff();
		}
	}

	private void DoorTrasparentOff() {
		Debug.Log ("Porta non trasparente");
		m_IsOpen = false;
		m_DoorCollider.isTrigger = false;
		m_DoorMaterial.color = new Color (m_DoorMaterial.color.r, m_DoorMaterial.color.b, m_DoorMaterial.color.g, 255f);
	}
}
