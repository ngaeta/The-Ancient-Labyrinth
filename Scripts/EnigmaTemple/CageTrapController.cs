using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrapController : MonoBehaviour {

	private Rigidbody m_Rigidbody;
	private int numberhit = 0;

	public IAMonsterController IAMonsterController;
	public Transform player;
	public NavMeshMonster navMesh;
	public VisionMonsterTrigger vision;
	public float forceForward = 5f;
	public float forceUpward = 100f;
	public GameObject triggerToActive, groundBroken;
	public AudioSource stoneDrop;
	public float timeToBrokeDoor = 14f;
	public SpawnLittleStones[] spawnStones;

	private bool m_DoorHit;
	private bool m_DoorCanBroke;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody> ();
		m_DoorCanBroke = false;
		m_DoorHit = false;
	}
	
	// Update is called once per frame
	void Update () {
		//m_Rigidbody.AddForce (transform.up * force);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Monster") && !m_DoorHit) {
			m_DoorHit = true;
			StartCoroutine (WaitToBrokeDoor ());
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.CompareTag ("Monster")) {
			SpawnStones ();
			stoneDrop.Play ();
			if (triggerToActive!= null && !triggerToActive.activeInHierarchy) {
				groundBroken.SetActive (true);
				triggerToActive.SetActive (true);
			}
			else if (m_DoorCanBroke) {
				ScriptingController.StopAllScripts ();
				m_Rigidbody.constraints = RigidbodyConstraints.None;
				Vector3 forces = transform.up * forceForward + transform.forward * forceUpward;
				//m_Rigidbody.AddForce (transform.up * force);
				m_Rigidbody.AddForce(forces);
				gameObject.layer = LayerMask.NameToLayer ("OnlyTerrain");
				Destroy (this);
			}
		}
	}

	private IEnumerator WaitToBrokeDoor() {
		yield return new WaitForSecondsRealtime (timeToBrokeDoor);
		m_DoorCanBroke = true;
	}

	private void SpawnStones() {
		foreach (SpawnLittleStones stones in spawnStones)
			stones.SpawnStones ();
	}
		
}
