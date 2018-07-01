using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavMeshMonster : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent m_NavMeshAgent;
	private Transform m_TargetPlayer = null;
	private Queue<Transform> m_QueueWaypoint;
	private bool m_CanWalk, m_NextWaypoint;
	private Transform lastWaypoint = null;
	private Transform m_NoiseHeard = null;
	public float speedWalk, accelerationWalk;
	public float speedRun = 4f;
	public float accelerationRun = 8f;
	public Transform currentZone; 
	private bool m_RandomDestination;
	public float[] timeToRandomDestination;
	private Transform[] m_CurrentWaypoints;

	void Awake() {
		m_NavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		IAMonsterController.OnRunEvent += RunMonster;
		IAMonsterController.OnWalkEvent += WalkMonster;
		IAMonsterController.OnRoarEvent += AlertMonster;
		IAMonsterController.OnTargetLost += TargetLost;
		IAMonsterController.OnLookAroundEvent += IdleMonster;
		IAMonsterController.OnAttackEvent += AttackMovement;
		speedWalk = m_NavMeshAgent.speed;
		accelerationWalk = m_NavMeshAgent.acceleration;
		m_QueueWaypoint = new Queue<Transform> ();
		m_CanWalk = true;
		m_NextWaypoint = true;
		m_RandomDestination = false;
		StartCoroutine (NextRandomDestination ());  //togliere in caso di problemi
	}

	void IAMonsterController_OnNoisHeard (Transform v)
	{
		IdleMonster ();
	}
		
	void FixedUpdate () {
		if (m_NavMeshAgent.enabled) {
			if (m_TargetPlayer != null && m_CanWalk)
				m_NavMeshAgent.SetDestination (m_TargetPlayer.position);
			else if (isArrivedAtDestination() && m_CanWalk && m_QueueWaypoint.Count > 0 && m_NextWaypoint) {
				m_NextWaypoint = false;
				NextDestination();
				StartCoroutine (n ());
			}
		}
	}

	public void AlertMonster(Transform target) {
		Debug.Log("Alert monster in " + this.GetType());
		transform.LookAt (target);
		m_CanWalk = false;
		m_NavMeshAgent.isStopped = true;

	}

	public void RunMonster(Transform target) {
		Debug.Log ("Run monster in " + this.GetType ());
		m_TargetPlayer = target;
		m_CanWalk = true;
		m_NavMeshAgent.acceleration = accelerationRun;
		m_NavMeshAgent.speed = speedRun;
		m_NavMeshAgent.isStopped = false;

	}

	public void WalkMonster(Transform t) {
		m_NavMeshAgent.acceleration = accelerationWalk;
		m_NavMeshAgent.speed = speedWalk;
		Debug.Log("Walk monster in " + this.GetType());
		if (!m_CanWalk) {
			m_NavMeshAgent.isStopped = false;
			m_CanWalk = true;
		} 
	}

	public void IdleMonster() {
		Debug.Log ("IDle monster in " + this.GetType ());
		m_CanWalk = false;
		m_NavMeshAgent.velocity = Vector3.zero;
		m_NavMeshAgent.acceleration = 0;
		m_NavMeshAgent.isStopped = true;
	}

	public void modificaPercorso(Transform[] waypointZone) {
		m_CurrentWaypoints = waypointZone;
		m_QueueWaypoint.Clear ();
		foreach (Transform t in waypointZone)
			m_QueueWaypoint.Enqueue (t);
		if(!m_TargetPlayer)
			m_NavMeshAgent.ResetPath ();
	}

	public void TargetLost () {
		Debug.Log ("Search Player in " + this.GetType ());
		m_TargetPlayer = null;
		m_NavMeshAgent.ResetPath ();
		NextDestination ();
	}

	public void DeactiveNavMeshAgent() {
		m_NavMeshAgent.enabled = false;
	}

	public void ActiveNavMeshAgent() {
		m_NavMeshAgent.enabled = true;
	}

	public void SetMainTarget(Transform t) {
		m_TargetPlayer = t;
	}

	public void AttackMovement(Transform target) {
		IdleMonster ();
		transform.LookAt (target);
	}

	public void NextDestination() {
		//m_NavMeshAgent.ResetPath ();
		Transform nextDestination = null;
		while(!nextDestination)  {
			//seleziona una destinazione casuale o presrtabilita
			if (m_RandomDestination) {
				m_RandomDestination = false;
				int random = Random.Range (0, m_CurrentWaypoints.Length);
				nextDestination = m_CurrentWaypoints [random];
				if (nextDestination != currentZone && nextDestination != null) {
					m_NavMeshAgent.SetDestination (nextDestination.position);
					currentZone = nextDestination;
					Debug.Log ("Nuova destinazione CASUALE " + nextDestination);
				} else
					nextDestination = null;
				StartCoroutine (NextRandomDestination ());
			} else {
				nextDestination = m_QueueWaypoint.Peek ();
				if (nextDestination != null) {
					m_NavMeshAgent.SetDestination (nextDestination.position);
					m_QueueWaypoint.Dequeue ();
					m_QueueWaypoint.Enqueue (nextDestination);
					currentZone = nextDestination;
					Debug.Log ("Nuova destinazione " + nextDestination);
				}
			}
		}
	}

	public void ResumeDestination() {
		m_NavMeshAgent.ResetPath ();
		m_NavMeshAgent.SetDestination (currentZone.position);
	}

	private IEnumerator n() {
		yield return new WaitForSecondsRealtime (1f);
		m_NextWaypoint = true;
	}

	private bool isArrivedAtDestination () {
		
		if (!m_NavMeshAgent.hasPath || m_NavMeshAgent.remainingDistance < 1f)  {
			return true;
		}
		return false;
	}


	public void Hitted() {
		IdleMonster ();
	}

	private IEnumerator NextRandomDestination() {
		int random = Random.Range (0, timeToRandomDestination.Length);
		yield return new WaitForSecondsRealtime (timeToRandomDestination [random]);
		m_RandomDestination = true;
	}

	void OnDisable() {
		IAMonsterController.OnRunEvent -= RunMonster;
		IAMonsterController.OnWalkEvent -= WalkMonster;
		IAMonsterController.OnRoarEvent -= AlertMonster;
		IAMonsterController.OnTargetLost -= TargetLost;
		IAMonsterController.OnLookAroundEvent -= IdleMonster;
		IAMonsterController.OnAttackEvent -= AttackMovement;
	}
}
