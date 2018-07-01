using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfterSeconds : MonoBehaviour {

	public float timeToDestroy =7f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
