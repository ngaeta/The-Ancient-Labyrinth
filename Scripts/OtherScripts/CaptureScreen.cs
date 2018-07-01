using UnityEngine;
using System.Collections;

public class CaptureScreen : MonoBehaviour {

	public string text = "c";
	private int i=0;


	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Foto");
			Application.CaptureScreenshot(text + i + ".png");
			i++;
		}
			
	}

	void OnMouseDown() {
		
	}
}