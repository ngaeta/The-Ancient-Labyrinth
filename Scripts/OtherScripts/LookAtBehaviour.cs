using UnityEngine;
using System.Collections;

public class LookAtBehaviour : MonoBehaviour {

	private Transform m_Target;
	public Transform creature;
	public float minAngleRotateHead = 0.2f;

	void Start() {
		IAMonsterController.OnRoarEvent += TargetLook;
		IAMonsterController.OnLookAroundEvent += TargetLost;
	}

	// Update is called once per frame
	void Update () 
    {
		if (m_Target != null)
		{
			Vector3 forw = creature.TransformDirection (Vector3.forward);
			Vector3 other = m_Target.position - creature.position;
			float angle = Vector3.Dot(forw, other);
			if(angle > minAngleRotateHead)
				transform.rotation = Quaternion.LookRotation (m_Target.position - transform.position) * Quaternion.Euler (145f, 1f, 1f);
        }
	}

	private void TargetLook(Transform target) {
		m_Target = target;
	}

	private void TargetLost() {
		m_Target = null;
	}
}
