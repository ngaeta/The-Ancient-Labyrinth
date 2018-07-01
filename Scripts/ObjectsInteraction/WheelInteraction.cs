using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInteraction : MonoBehaviour, ObjectInteraction {

	public AudioInterface audioScript;
	public GameObject[] rayObjects;
	public byte ActualColorValue = 255;
	public static int rangeColor = 1;
	public static float forceRotation = 0.01f;
	public Color32 ActualColor;
	public ColorRayController colorRayController;


	private Rigidbody m_RigidBody;
	private List<Material> materialsRay = new List<Material>();
	public enum RGB
	{
		RED, GREEN, BLUE
	}
	public RGB colorRay = RGB.RED;

	void Start() {
		m_RigidBody = GetComponent<Rigidbody> ();
		m_RigidBody.maxAngularVelocity = forceRotation + 1;
		foreach (GameObject g in rayObjects) 
			materialsRay.Add (g.GetComponent<MeshRenderer> ().material);
	}

	public void OnHeld() {
		Rotate ();
	}

	public void OnRelease() {
		audioScript.Stop ();
		m_RigidBody.angularVelocity = Vector3.zero;
	}

	private void ChangeColorMaterials() {
		switch (colorRay) {
		case RGB.RED:
			ActualColor.r = ActualColorValue;
			break;
		case RGB.GREEN:
			ActualColor.g = ActualColorValue;
			break;
		case RGB.BLUE:
			ActualColor.b = ActualColorValue;
			break;
		}

		foreach (Material m in materialsRay) 
			m.SetColor ("_TintColor", ActualColor);
	}

	public void OnClick() {
		Rotate ();
	}

	private void Rotate() {
		if (colorRayController != null) {
			audioScript.Play ();
			m_RigidBody.AddRelativeTorque (new Vector3 (0f, forceRotation, 0f));
			ActualColorValue++;
			if (ActualColorValue > 255)
				ActualColorValue = 0;
			ChangeColorMaterials ();
			colorRayController.ChangeColorRay ();
		} else
			Destroy (this);
	}
}
