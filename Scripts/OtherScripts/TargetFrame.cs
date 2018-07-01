using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrame : MonoBehaviour {

	public int target = 60;
	// Use this for initialization
	void Awake () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = target;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(target != Application.targetFrameRate)
			Application.targetFrameRate = target;*/
	}
}
