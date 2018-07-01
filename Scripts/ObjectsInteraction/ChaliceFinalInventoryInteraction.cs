using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceFinalInventoryInteraction : ObjectInventoryInteraction {

	public int WaterNecessary = 2;
	public ChaliceFinalPlayerInteraction chaliceInteraction;
	public GameObject waterGood, waterEvil, waterFinal;
	public ChalicePickInteraction chaliceGood, chaliceEvil;

	private int m_CurrentWaterInsered;

	// Use this for initialization
	void Start () {
		m_CurrentWaterInsered = 0;
	}

	#region implemented abstract members of ObjectInventoryInteraction

	public override void UseObject (PickObjectInteraction objectUsed)
	{
		if (ControlObjectUsed (objectUsed)) {
			ChalicePickInteraction chalice = objectUsed.GetComponent<ChalicePickInteraction> ();
			if (chalice != null && !chalice.IsEmpty) {
				InventoryPlayer.Remove (objectUsed);
				PlayAudio ();
				m_CurrentWaterInsered++;
				ControlWater (chalice);
			}
		}
	}

	#endregion

	private void ControlWater(ChalicePickInteraction chalice) {
		
		if (m_CurrentWaterInsered >= WaterNecessary) {
			chaliceInteraction.IsEmpty = false;
			Destroy (waterGood);
			Destroy (waterEvil);
			waterFinal.SetActive (true);
			Destroy (this);
		}
		else if (chalice == chaliceGood) {
			waterGood.SetActive (true);
			Destroy (waterEvil);
		} else if (chalice == chaliceEvil) {
			waterEvil.SetActive (true);
			Destroy (waterGood);
		}
	}
}
