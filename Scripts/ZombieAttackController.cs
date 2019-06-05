using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackController : MonoBehaviour {

	public ZombieMummyController zombie;
	public int MaxNumberToAttackAgain = 3;

	private int m_Attack;
	private bool m_CanAttack;

	void Awake() {
		m_CanAttack = false;
		zombie.OnAttackEndEvent += CanAttack;
		m_Attack = 0;
	}

	void OnTriggerStay(Collider collision) {
		Debug.Log ("collision with zombie ");
		if (m_CanAttack && m_Attack <= MaxNumberToAttackAgain && collision.gameObject.CompareTag ("Player")) {
			m_CanAttack = false;
			zombie.Attack ();
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) 
			m_Attack = 0;
	}
		
	public void CanAttack() {
		m_Attack++;
		m_CanAttack = true;
	}

	void OnDisable() {
		zombie.OnAttackEndEvent -= CanAttack;
	}


}
