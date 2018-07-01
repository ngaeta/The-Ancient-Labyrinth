using UnityEngine;
using System.Collections;

public class AnimatorMonster : MonoBehaviour {

	private Animator m_Animator;
	private int m_AlertHashTrigger;
	private int m_WalkHashTrigger;
	private int m_SearchHashTrigger;
	private int m_RunHashTrigger;
	private int m_AttackTrigger;
	private int m_HitTrigger;

	private AnimatorStateInfo animatorState;

	void Awake() {
		m_Animator = GetComponent<Animator> ();
		m_RunHashTrigger = Animator.StringToHash ("Run");
		m_SearchHashTrigger = Animator.StringToHash ("Search");
		m_AlertHashTrigger = Animator.StringToHash ("Alert");
		m_WalkHashTrigger = Animator.StringToHash ("Walk");
		m_AttackTrigger = Animator.StringToHash ("Attack");
		m_HitTrigger = Animator.StringToHash ("Hit");
		IAMonsterController.OnRoarEvent += AlertMonster;
		IAMonsterController.OnRunEvent += RunMonster;
		IAMonsterController.OnWalkEvent += WalkMonster;
		IAMonsterController.OnLookAroundEvent += IdleMonster;
		IAMonsterController.OnAttackEvent += AttackAnimation;

	}

	public void AlertMonster(Transform target) {
		m_Animator.SetTrigger (m_AlertHashTrigger);
	}

	public void WalkMonster(Transform target) {
		m_Animator.SetTrigger (m_WalkHashTrigger);
	}

	public void IdleMonster() {
		m_Animator.SetTrigger (m_SearchHashTrigger);
	}

	public void RunMonster(Transform target) {
		m_Animator.SetTrigger (m_RunHashTrigger);
	}

	public void AttackAnimation(Transform target) {
		m_Animator.SetTrigger (m_AttackTrigger);
	}

	public void Hitted() {
		m_Animator.SetTrigger (m_HitTrigger);
	}

	void OnDisable() {
		IAMonsterController.OnRoarEvent -= AlertMonster;
		IAMonsterController.OnRunEvent -= RunMonster;
		IAMonsterController.OnWalkEvent -= WalkMonster;
		IAMonsterController.OnLookAroundEvent -= IdleMonster;
		IAMonsterController.OnAttackEvent -= AttackAnimation;
	}
}
