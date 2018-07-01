using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiStatueEyeController : MonoBehaviour {

	public MeshRenderer[] meshEyesAnubiStatue;
	public GemInteractionEnigma[] gemOrder;
	public Color[] orderColorEye;
	public Color colorEyeFinal;

	private List<GemInteractionEnigma> gemInsered = new List<GemInteractionEnigma> ();
	private Color m_ColorDefaut;
	private int m_NextGem;
	private bool m_SequenceCorrect = true;
	private Material m_MaterialLeftEye, m_MaterialRightEye;

	void Start() {
		m_MaterialLeftEye = meshEyesAnubiStatue[0].material;
		m_MaterialRightEye = meshEyesAnubiStatue [1].material;
		m_ColorDefaut = m_MaterialLeftEye.color;
		m_NextGem = 0;
	}

	public void GemSwitched(GemInteractionEnigma gem) {
		gemInsered.Add (gem);
		if (m_SequenceCorrect) 
		{
			if (gemInsered.Count >= gemOrder.Length) 
				ControlEnigma ();
			else if (gem.gameObject == gemOrder [m_NextGem].gameObject) {
				++m_NextGem;
				ChangeEyeColor (orderColorEye [m_NextGem]);
			}
			else {
				m_SequenceCorrect = false;
				m_NextGem = 0;
				ChangeEyeColor (m_ColorDefaut);
			}
		} 
		else if (gemInsered.Count >= gemOrder.Length) 
			ControlEnigma ();
	}

	private void ChangeEyeColor(Color color) {
		m_MaterialRightEye.SetColor ("_Color", color);
		m_MaterialRightEye.SetColor ("_EmissionColor", color);
		m_MaterialLeftEye.SetColor ("_Color", color);
		m_MaterialLeftEye.SetColor ("_EmissionColor", color);
	}

	private void ControlEnigma() {
		for(int i=0; i< gemOrder.Length; i++) {
			if (gemOrder [i].gameObject != gemInsered [i].gameObject) {
				gemInsered.Clear ();
				m_SequenceCorrect = true;
				return;
			}
		}
		ChangeEyeColor (colorEyeFinal);
		Destroy (this);
	}
}
