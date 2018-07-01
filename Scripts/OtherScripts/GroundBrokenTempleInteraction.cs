using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBrokenTempleInteraction : MonoBehaviour, ObjectInteraction {

	public GameObject groundBrokemn;
	public GameObject gameToActive;

	private Rigidbody m_RigidBody;
	private BoxCollider m_BoxCollider;
	private AudioSource m_AudioSource;
	private int m_NumberHit;
	public int numberHitToBroke;
	private bool m_CanNextHit;
	public float timeToNextHit = 1f;
	public GameObject[] groundBrokenToActive;

	// Use this for initialization
	void Start () {
		m_RigidBody = groundBrokemn.GetComponent<Rigidbody> ();
		m_BoxCollider = groundBrokemn.GetComponent<BoxCollider> ();
		m_AudioSource = groundBrokemn.GetComponent<AudioSource> ();
		m_NumberHit = 0;
		m_CanNextHit = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		
		if (m_NumberHit >= numberHitToBroke && m_CanNextHit) {
			gameToActive.SetActive (true); // per attivare spider
			m_BoxCollider.isTrigger = true;
			m_AudioSource.Play ();
			m_RigidBody.isKinematic = false;
			m_RigidBody.useGravity = true;
			Destroy (groundBrokemn, 5f);
			Destroy (this);
		} else {
			if (m_CanNextHit && m_NumberHit < numberHitToBroke) {
				m_AudioSource.Play ();
				m_CanNextHit = false;
				groundBrokenToActive [m_NumberHit].SetActive (true);
				m_NumberHit++;
				StartCoroutine (WaitToNextHit ());
			}
		}
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion

	private IEnumerator WaitToNextHit()  {
		yield return new WaitForSeconds (timeToNextHit);
		m_CanNextHit = true;
	}
}
