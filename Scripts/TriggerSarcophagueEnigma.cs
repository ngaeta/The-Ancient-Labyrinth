using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSarcophagueEnigma : MonoBehaviour {

	private static int m_NumberPlayerTouch;
	private static bool m_PlayerTouch;

	public float sogliaSpawn = 10f;
	public VisionMonsterTrigger vision;
	public Transform waypointSarcophague;
	public Transform SpawnMonsterPosition;
	public GameObject monster;
	public AudioClip clipFirstTouch, clipSecondTouch;
	public AudioSarcophagueInteraction audio;
	public DoorSarcophague script;
	public IAMonsterController IAMonsterController;

	void Start() {
		m_NumberPlayerTouch = 0;
		m_PlayerTouch = false;
	}

	void OnTriggerEnter(Collider collider) {
		
		if (collider.gameObject.CompareTag ("Player") && m_PlayerTouch) {
			m_PlayerTouch = false;
			if (m_NumberPlayerTouch == 1) {
				audio.Play ();
			} else if (m_NumberPlayerTouch == 2) {
				audio.ChangeClipAndPlay (clipSecondTouch);
				PlayerTouchedSarcophague ();
			} else {
				script.ExplodeDoor ();
				if ((monster.transform.position - transform.position).magnitude > sogliaSpawn && !vision.PlayerSeen) {
					monster.GetComponent<NavMeshMonster> ().DeactiveNavMeshAgent ();
					monster.transform.position = SpawnMonsterPosition.position;
					monster.GetComponent<NavMeshMonster> ().ActiveNavMeshAgent ();
					waypointSarcophague.gameObject.SetActive (true);
					IAMonsterController.RoarAndAfterRun (waypointSarcophague);
					monster.transform.Find ("HearMonster").gameObject.SetActive (true);  // momentaneamente perchè hear vine disabilitato
				}
				Destroy (gameObject);
			}
		}
	}
			
	public static void PlayerTouchedSarcophague() {
		if (!m_PlayerTouch) {
			m_PlayerTouch = true;
			m_NumberPlayerTouch++;
		}
	}
}
