using UnityEngine;
using System.Collections;

public class ZoneSearchMonster : MonoBehaviour {

	public Transform[] waypointZone;


	private bool isAlreadyInTriggerZone;
	public IAMonsterController IAMonsterController;

	// Use this for initialization
	void Start () {
		isAlreadyInTriggerZone = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log (collider.gameObject.name);
		if (!isAlreadyInTriggerZone && collider.gameObject.CompareTag ("Player")) {
			//Debug.Log("Player in " + gameObject.name);
			isAlreadyInTriggerZone = true;
			IAMonsterController.ChangeMonsterPercorso (waypointZone);
		}
	}

	void OnTriggerExit(Collider collider) {
		
		if (collider.gameObject.CompareTag ("Player")) {
			isAlreadyInTriggerZone = false;
		}
	}
}
