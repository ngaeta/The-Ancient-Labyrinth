using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavMeshController : MonoBehaviour {

	private NavMeshAgent n;
	public Transform destination;

	// Use this for initialization
	void Start () {
		n = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		n.SetDestination (destination.position);
	}

	public void Stop() {
		n.isStopped = true;
	}
}
