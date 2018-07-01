using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackTempleScripting : MonoBehaviour, IScripting {

	public Animator m_Animator;
	public NavMeshMonster navMesh;
	public Rigidbody r;
	public IAMonsterController IAMonsterController;
	public Transform playerTarget;
	public Transform cage;
	private bool i = false;
	public VisionMonsterTrigger vision;
	public NavMeshMonster nav;
	public bool PlayerInCage = true;


	#region IScripting implementation

	public void StartScript ()
	{
		vision.gameObject.SetActive (false);
		IAMonsterController.Attack (cage);

	}

	public void StopScript ()
	{
		
		vision.gameObject.SetActive (true);

		if (PlayerInCage) {
			IAMonsterController.RoarAndAfterRun (playerTarget);
		} else {
			vision.PlayerLost ();
		}

		Destroy (gameObject);
	}

	#endregion

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Monster") && !i) {
			i = true;
			ScriptingController.StartScript (this);
		}
	}

}
