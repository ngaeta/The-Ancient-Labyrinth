using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPosition : MonoBehaviour {

	private Quaternion targetRotation;

	public VisionMonsterTrigger vision;
	public Transform target = null;
	public float velocityRotation = 1f;
	public float degreesRotation = 10f;
	public IAMonsterController iaMonster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			targetRotation = Quaternion.LookRotation (target.position - transform.position, Vector3.up);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, velocityRotation * Time.deltaTime);
				Debug.Log (Quaternion.Angle (targetRotation, transform.rotation));
				if (Quaternion.Angle (targetRotation, transform.rotation) < degreesRotation) {
					iaMonster.LookAroundAndAfterWalk (null);
					target = null;
				} 
		}
	}
}
