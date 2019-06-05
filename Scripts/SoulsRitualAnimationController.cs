using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class SoulsRitualAnimationController : MonoBehaviour {

	public Blur blur;
	public VignetteAndChromaticAberration vignette;
	public float intensityVignette = 0.35f;
	public float timeToModifyBlur = 0.1f;
	public bool stopBlur = false;
	public float maxBlur = 1;


	public void StartAnimation() {
		vignette.enabled = true;
		vignette.intensity = intensityVignette;
		blur.enabled = true;
		StartCoroutine (StartBlurAnimation ());
	}


	private IEnumerator StartBlurAnimation() {
		while (!stopBlur) {
			yield return new WaitForSeconds (timeToModifyBlur);
			if (blur.iterations < maxBlur)
				blur.iterations++;
			else 
				blur.iterations--;
		}
		vignette.intensity = 0;
		vignette.enabled = false;
		blur.iterations = 0;
		blur.enabled = false;
	}
}
