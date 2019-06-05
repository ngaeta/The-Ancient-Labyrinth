using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMummyController : MonoBehaviour {

	public AudioZombieMummyController audioZombie;
	public LookAtTarget l;
	public string triggerNameAttack = "Attack";
	public delegate void OnAnimationAttackEnd();
	public event OnAnimationAttackEnd OnAttackEndEvent;
	public string TriggeNameWalk = "Walk";
	public AudioClip[] ClipFootStep;
	public AudioSource AudioFootStep;

	public ZombieNavMeshController zombieNav;
	private int m_NextFootStep;
	private bool m_Attacking;
	private Animator m_Animator;
	private int m_HashTriggerAttack;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
		m_HashTriggerAttack = Animator.StringToHash (triggerNameAttack);
		m_Attacking = false;
		m_NextFootStep = 0;
	}
	
	public void Attack() {
		if (!m_Attacking) {
			if (zombieNav != null && zombieNav.enabled)
				zombieNav.Stop ();
			m_Animator.enabled = true;
			m_Attacking = true;
			m_Animator.SetTrigger (m_HashTriggerAttack);
			audioZombie.PlayAttack ();
		}
	}

	public void AnimationFinished() {
		m_Animator.enabled = false;
		if(l!=null)
			l.enabled = true;
		m_Attacking=false;
		if (OnAttackEndEvent != null)
			OnAttackEndEvent ();
	}

	public void NextRoar() {
		if (!m_Attacking) {
			audioZombie.PlayRoar ();
		}
	}

	public bool IsAttacking {
		get { 
			return m_Attacking;
		}
	}

	public void Walk() {
		m_Animator.SetTrigger (TriggeNameWalk);
		zombieNav.enabled = true;
	}

	public void FootStepWalk() {
		AudioFootStep.clip = ClipFootStep [m_NextFootStep];
		AudioFootStep.Play ();
		m_NextFootStep = (m_NextFootStep + 1) % ClipFootStep.Length;
	}
}
