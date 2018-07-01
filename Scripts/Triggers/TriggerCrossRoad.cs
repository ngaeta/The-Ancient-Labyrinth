using UnityEngine;
using System.Collections;

public class TriggerCrossRoad : MonoBehaviour {

	public VisionMonsterTrigger visionMonster;
	public float timeToLostPlayerInCrossRoad = 3f;
	public IAMonsterController IAMonsterController;
	private bool m_PlayerLosted = false;

	void OnTriggerEnter(Collider collider) {

		if (collider.gameObject.CompareTag ("Player") && !visionMonster.PlayerInTriggerVision && visionMonster.TimeSinceLostPlayer >= timeToLostPlayerInCrossRoad)
			m_PlayerLosted=true;
		
		else if (collider.gameObject.CompareTag ("Monster")) {
			//Debug.Log ("Monster in " + gameObject.name);
			if (m_PlayerLosted) {
				if(IAMonsterController.monsterState == MonsterAction.MONSTER_ACTION.RUN)  {
					Debug.Log ("Mostro in " + gameObject.name + " ha perso di vista il giocatore");
					visionMonster.PlayerLost ();
				}
				else
					m_PlayerLosted = false;
			}
		}
	}
}
