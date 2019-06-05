using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActiveSpider : MonoBehaviour {

	public SpiderController spider;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			spider.RunSpider ();
			Destroy (gameObject);
		}
	}
}
