using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget: MonoBehaviour {

	public Transform m_Target;
	public Transform creature;
	public float minAngleRotateHead = 0.2f;

	public Vector3 offsetVector = new Vector3(1f, -85f, -65f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			if (m_Target != null)
		{
			
			Vector3 forw = creature.TransformDirection (Vector3.forward);
			Vector3 other = m_Target.position - creature.position;
			float angle = Vector3.Dot(forw, other);
			if (angle > minAngleRotateHead)
				transform.rotation = Quaternion.LookRotation (m_Target.position - transform.position) * Quaternion.Euler (offsetVector);
			}
		}

}
