using UnityEngine;
using System.Collections;

public class IAMonsterController : MonoBehaviour {
	//rendere tutti non statici 
	public  NavMeshMonster nav;
	public float timeToRunAfterRoar = 3f;
	public  float timeToWalkAfterLookAround = 4f;
	public float timeToTurnAfterLookAround = 1.5f;
	public GameObject gameObjectHearMonster;

	public delegate void MonsterActionMove (Transform atPosition);
	public delegate void MonsterActionStop();
	public delegate void MonsterNoiseHear(Transform v);
	public static event MonsterActionMove OnRunEvent, OnWalkEvent, OnRoarEvent, OnAttackEvent;
	public static event MonsterActionStop OnLookAroundEvent,  OnTargetLost;

	public MonsterAction.MONSTER_ACTION monsterState;

	void Start() {
		nav = GetComponent<NavMeshMonster> ();
		Walk (null);
	}

	public void Walk(Transform atPosition) {
		monsterState = MonsterAction.MONSTER_ACTION.WALK;
		if (OnWalkEvent != null)
			OnWalkEvent (atPosition);
	}

	public void Roar(Transform target) {
		DeactiveTurn ();
		StopAllCoroutines ();  //x risolvere problema che quando in search player rivedeva il giocatore ma camminava
		monsterState = MonsterAction.MONSTER_ACTION.ROAR;
		if (OnRoarEvent != null)
			OnRoarEvent (target);
	}

	public void RoarAndAfterRun(Transform targetToRun) {
		Roar (targetToRun);
		StartCoroutine (WaitToRun(targetToRun));
	}

	public void Run(Transform atTarget) {
		DeactiveTurn ();
		monsterState = MonsterAction.MONSTER_ACTION.RUN;
		if(OnRunEvent != null)
			OnRunEvent(atTarget);
	}

	public void ChangeMonsterPercorso(Transform[] newPercorso) {
		nav.modificaPercorso (newPercorso);
	}

	public void LookAround() {
		monsterState = MonsterAction.MONSTER_ACTION.LOOK_AROUND;
		if (OnLookAroundEvent != null)
			OnLookAroundEvent ();
	}

	public void TargetLost() {
		LookAroundAndAfterWalk (null);
		if (OnTargetLost != null)
			OnTargetLost ();
	}

	public void LookAroundAndAfterWalk(Transform atTarget) {
		gameObjectHearMonster.SetActive (true);
		LookAround ();
		StartCoroutine (WaitToWalk (atTarget));
	}

	public void SetScriptingState() {
		monsterState = MonsterAction.MONSTER_ACTION.SCRIPTING;
	}
		
	private IEnumerator WaitToRun(Transform target) {
		yield return new WaitForSecondsRealtime (timeToRunAfterRoar);
		Run (target);
	}

	private IEnumerator WaitToWalk(Transform atTarget) {
		yield return new WaitForSecondsRealtime (timeToWalkAfterLookAround);
		Walk (atTarget);
	}

	public MonsterAction.MONSTER_ACTION MonsterState {
		get {
			return monsterState;
		}
	}

	public void Attack(Transform targetToAttack) {
		if (OnAttackEvent != null)
			OnAttackEvent (targetToAttack);
	}

	public void WalkAtTarget(Transform target) {
		Walk (target);
		nav.SetMainTarget (target);
	}

	private void DeactiveTurn() {
		gameObjectHearMonster.SetActive (false);
	}

	public void RoarAndAfterAttack (Transform targetAttack) {
		Roar (targetAttack);
		StartCoroutine (WaitToAttack(targetAttack));
	}

	private IEnumerator WaitToAttack(Transform targetToAttack) {
		yield return new WaitForSecondsRealtime(timeToRunAfterRoar);
		Attack(targetToAttack);
	}

	public void RoarAndAfterWalk(Transform targetToRun) {
		Roar (targetToRun);
		StartCoroutine (WaitToWalk(targetToRun));
	}
}
