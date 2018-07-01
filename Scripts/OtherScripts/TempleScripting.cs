using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleScripting : MonoBehaviour, IScripting {

	public GameObject cageForward, cageBackward;
	public NavMeshMonster navMeshMonster;
	public Transform monsterDestination;
	public IAMonsterController IAMonsterController;
	public VisionMonsterTrigger vision;
	public GameObject[] gameObjectToDestroy;

	private Animator m_AnimatorCageForward, m_AnimatorCageBackward;
	public bool m_CanActive = false;

	// Use this for initialization
	void Start () {
		//m_CanActive = false;
		m_AnimatorCageForward = cageForward.GetComponent<Animator> ();
		m_AnimatorCageBackward = cageBackward.GetComponent<Animator> ();
	}

	#region IScripting implementation

	public void StopScript ()
	{
		
	}

	public void StartScript ()
	{
		monsterDestination.gameObject.SetActive (true);
		cageForward.SetActive (true);
		cageBackward.SetActive (true);
		IAMonsterController.WalkAtTarget (monsterDestination);
	}

	#endregion


	void OnTriggerEnter(Collider collider) {
		if (m_CanActive & collider.gameObject.CompareTag ("Player")) {
			m_AnimatorCageForward.enabled = true;
			m_AnimatorCageBackward.enabled = true;
			ScriptingController.StartScript (this);
			DestroyGameObjects ();
			Destroy (gameObject);
		}
	}

	public bool CanActive {
		set {
			m_CanActive = value;
		}
	}

	private void DestroyGameObjects() {
		foreach (GameObject g in gameObjectToDestroy)
			Destroy (g);
	}

}
