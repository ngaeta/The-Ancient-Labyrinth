using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HearMonsterController : MonoBehaviour {

	public IAMonsterController iaMonster;
	public VisionMonsterTrigger vision;
	public FirstPersonController fps;
	private BoxCollider hearTrigger;
	private bool alreadyAddedHear = false;

	void Start() {
		hearTrigger = GetComponent<BoxCollider> ();
	}

	void OnTriggerStay(Collider collider) {
	
		if (collider.gameObject.CompareTag ("Player") && !vision.PlayerSeen) {
			if (!fps.IsStopped) {
				Debug.Log ("ho sentito il giocatore");
				vision.PlayerVisto (collider.gameObject.transform);
			} else
				Debug.Log ("E fermo");
		}
	}
		
	void FixedUpdate() {
		if (!fps.IsStopped) {
			if (!alreadyAddedHear && Input.GetKey (KeyCode.LeftShift))
				AddHear ();
			else if (alreadyAddedHear && Input.GetKeyUp (KeyCode.LeftShift))
				ReduceHear ();
		} else if (alreadyAddedHear) {
			ReduceHear ();
		}
	}

	public void AddHear() {
		alreadyAddedHear = true;
		Vector3 newSize = new Vector3 (hearTrigger.center.x, hearTrigger.center.y, -2.5f);
		hearTrigger.center = newSize;
		newSize =  new Vector3 (hearTrigger.size.x, hearTrigger.size.y, 7f);
		hearTrigger.size = newSize;
	}

	public void ReduceHear() {
		alreadyAddedHear = false;
		Vector3 newSize = new Vector3 (hearTrigger.center.x, hearTrigger.center.y, 0);
		hearTrigger.center = newSize;
		newSize =  new Vector3 (hearTrigger.size.x, hearTrigger.size.y, 5.55f);
		hearTrigger.size= newSize;
	}
}
