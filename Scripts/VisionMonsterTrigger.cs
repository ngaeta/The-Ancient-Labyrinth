using UnityEngine;
using System.Collections;

public class VisionMonsterTrigger : MonoBehaviour {

	public string[] layerStringToIgnore;
	public float offsetYRay = 0.4f, timeToStopAfterLostSightPlayer = 5f;


	private bool m_PlayerInTriggerVision = false;
	private float m_TimeSinceLostPlayer = 0f;
	private bool m_CoroutinePlay = false, m_PlayerSeen= false;
	private LayerMask mask;
	private BoxCollider visionTrigger;
	public IAMonsterController IAMonsterController;
	//prima stava in awake, in caso di problemi rimetterlo in awake
	void Start() {
		visionTrigger = GetComponent<BoxCollider> ();
		mask = 1 << LayerMask.NameToLayer ("Enemy");
		if(layerStringToIgnore.Length > 0)
			inizializzaLayerMask ();
	}

	void Update() {
		
		if (m_CoroutinePlay && m_TimeSinceLostPlayer > timeToStopAfterLostSightPlayer) {
			
			PlayerLost ();
		}
	}
		
	void OnTriggerStay(Collider collider) {
		
		if (collider.gameObject.CompareTag ("Player")) {
			if (!m_PlayerSeen || m_CoroutinePlay) {
				float distanceRay = Vector3.Distance (collider.transform.position, transform.position); //distanza tra mostro e il giocatore nel trigger visivo
				Vector3 directionRay = collider.transform.position - transform.position;
				Debug.DrawRay (transform.position + transform.up * offsetYRay, directionRay, Color.red, 20, true);
				RaycastHit hit; 

				if (Physics.Raycast (transform.position + transform.up * offsetYRay, directionRay, out hit, distanceRay, ~mask)) {
					if (hit.collider.gameObject.CompareTag ("Player")) {
						
						PlayerVisto (collider.transform);
						/*StopAllCoroutines ();
						m_PlayerInTriggerVision = true;
						if (!m_PlayerSeen) {
							m_PlayerSeen = true;
							IAMonsterController.RoarAndAfterRun (collider.transform);
						} else if (m_CoroutinePlay) {
							m_CoroutinePlay = false;
							m_TimeSinceLostPlayer = 0f;
							StopCoroutine ("WaitSeconds");
						}*/
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider collider) {

		if (m_PlayerSeen && (collider.gameObject.CompareTag ("Player")|| collider.gameObject.CompareTag("VisPlayer"))) {
			m_PlayerInTriggerVision = false;
			StartCoroutine ("WaitSeconds");
		}
	}

	private IEnumerator WaitSeconds() {
		Debug.Log ("cOROUTINE PARTITA");
		m_TimeSinceLostPlayer = 0f;
		m_CoroutinePlay = true;
		while(m_TimeSinceLostPlayer < timeToStopAfterLostSightPlayer) { 
			yield return new WaitForSecondsRealtime (1f);
			++m_TimeSinceLostPlayer;
			Debug.Log ("tEMPO TRASCORSO  " + m_TimeSinceLostPlayer);
		}
		PlayerLost ();
		m_PlayerSeen = false;
	}

	private void inizializzaLayerMask() {

		foreach (string layerName in layerStringToIgnore) {
			mask |= (1 << LayerMask.NameToLayer (layerName));
		}
	}

	public bool PlayerSeen {
		get {
			return m_PlayerSeen;
		}
	}

	public float TimeSinceLostPlayer {
		get {
			return m_TimeSinceLostPlayer;
		}
	}

	public bool PlayerInTriggerVision {
		get {
			return m_PlayerInTriggerVision;
		}
		set {
			m_PlayerInTriggerVision = value;
		}
	}

	public void PlayerLost() {
		Debug.Log ("sTOP COROUTINE IN PLAYE lost");
		m_CoroutinePlay = false;
		StopAllCoroutines ();
		m_TimeSinceLostPlayer = 0f;
		m_PlayerSeen = false;
		IAMonsterController.TargetLost ();
	}

	public void PlayerVisto(Transform playerTransform) {
		StopAllCoroutines ();
		m_PlayerInTriggerVision = true;
		if (!m_PlayerSeen) {
			m_PlayerSeen = true;
			IAMonsterController.RoarAndAfterRun (playerTransform);
		} else if (m_CoroutinePlay) {
			m_CoroutinePlay = false;
			m_TimeSinceLostPlayer = 0f;
			StopCoroutine ("WaitSeconds");
		}
	}

	public void AddVisibility() {
		Vector3 newSize = new Vector3 (visionTrigger.center.x, visionTrigger.center.y, 8.6f);
		visionTrigger.center = newSize;
		newSize =  new Vector3 (6f, visionTrigger.size.y, 16f);
		visionTrigger.size = newSize;
	}

	public void ReduceVisibility() {
		Vector3 newSize = new Vector3 (visionTrigger.center.x, visionTrigger.center.y, 5.8f);
		visionTrigger.center = newSize;
		newSize =  new Vector3 (5f, visionTrigger.size.y, 10.5f);
		visionTrigger.size = newSize;
	}
}
