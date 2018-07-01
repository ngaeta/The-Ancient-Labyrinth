using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MouseCursor : MonoBehaviour {

	public string layerToConsider = "PlayerInteraction";
	public Sprite handSprite;
	public Image imageCursor;
	public float distanceRay = 0.5f;
	public delegate void ScriptDisabled ();
	public static event ScriptDisabled OnScriptDisabledEvent;

	private GameObject m_OverObject = null;
	private MeshRenderer m_MeshRenderer;
	private bool m_OnObject = false;
	private LayerMask mask;

	void Awake() {
		m_MeshRenderer = GetComponent<MeshRenderer> ();
	}

	void Start () {
		mask = 1 << LayerMask.NameToLayer (layerToConsider);
		imageCursor.gameObject.SetActive (false);
		enabled = false;
	}

	void FixedUpdate () {

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, distanceRay, mask)) {
			if (!m_OnObject) {
				Debug.Log ("On " + hit.collider.gameObject.name);
				m_OnObject = true;
				m_OverObject = hit.collider.gameObject;
				m_MeshRenderer.enabled = false;
				imageCursor.gameObject.SetActive (true);
				imageCursor.sprite = handSprite;
			}
				
		} else if (m_OnObject) {
			m_OnObject = false;
			m_OverObject = null;
			m_MeshRenderer.enabled = true;
			imageCursor.gameObject.SetActive (false);
		}
	}
		
	void OnDisable () {
		if (OnScriptDisabledEvent != null)
			OnScriptDisabledEvent ();

		if (m_OnObject) {
			m_OnObject = false;
			m_OverObject = null;
			m_MeshRenderer.enabled = true;
			imageCursor.gameObject.SetActive (false);
		}
	}

	public GameObject OverObject {
		get {
			return m_OverObject;
		} set {
			m_OverObject = value;
		}
	}
}
