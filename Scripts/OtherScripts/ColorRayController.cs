using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRayController : MonoBehaviour {

	public GameObject[] finalRayObjects;
	public Color32 ActualColor;
	public WheelInteraction redRay, greenRay, blueRay;
	public RuneStoneEnigmaController runeScript;

	private List<Material> materialsRay = new List<Material>();

	void Start() {
		foreach (GameObject g in finalRayObjects) 
			materialsRay.Add (g.GetComponent<MeshRenderer> ().material);
		
	}

	public void ChangeColorRay() {
		if (runeScript != null) {
			foreach (Material material in materialsRay) {
				ActualColor = new Color32 (redRay.ActualColorValue, greenRay.ActualColorValue, blueRay.ActualColorValue, 255);
				Debug.Log ("Actual color " + ActualColor.ToString ());
				material.SetColor ("_TintColor", ActualColor);
			}
			runeScript.ControlRay (ActualColor);
		} else
			Destroy (this);
	}
}
