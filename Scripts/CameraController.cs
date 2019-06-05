using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
	}

	public void ChangeFlag(CameraClearFlags newFlags) {
		mainCamera.clearFlags = newFlags;
	}

	public void ChangeLayer(string newLayer) {
		mainCamera.cullingMask = 1 << LayerMask.NameToLayer (newLayer);
	}

	public void ChangeColor(Color color) {
		mainCamera.backgroundColor = color;
	}
}
