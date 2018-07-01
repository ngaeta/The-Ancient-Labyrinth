using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStoneEnigmaController : MonoBehaviour {

	[Range(0, 255)]public int minBlueRange;
	[Range(0, 255)]public int  maxBlueRange, minRedGreenRange = 70, minDifferenceRedGreen = 25;
	public GameObject energy;
	public GameObject gem;

	public void ControlRay(Color32 color) {
		if (color.b > minBlueRange && color.b < maxBlueRange &&(color.r - color.g >=  minDifferenceRedGreen && color.r > minRedGreenRange && color.g > minRedGreenRange)) {
			energy.SetActive (false);
			gem.layer = LayerMask.NameToLayer ("PlayerInteraction");
			Destroy (this);
		}
	}
}
