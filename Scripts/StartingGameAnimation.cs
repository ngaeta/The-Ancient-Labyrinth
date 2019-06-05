using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class StartingGameAnimation : MonoBehaviour {

	public Animator anim;
	public Blur blurScript;
	public float timeToModifyBlur=1f;
	public UIManager ui;
	public GameObject g;
	public GameObject UI;

	void Start() {
		/*cc.enabled = false;
		fps.enabled = false;*/
		blurScript.enabled = true;
		ui.enabled = false;
		UI.SetActive (false);
		anim.enabled = true;
		StartCoroutine (StartBlurAnimation ());
	}

	private IEnumerator StartBlurAnimation() {
		while (blurScript.iterations != 0) {
			yield return new WaitForSecondsRealtime (timeToModifyBlur);
			blurScript.iterations--;
		}

		UI.SetActive (true);
		ui.enabled = true;
		blurScript.enabled = false;
		yield return new WaitForSecondsRealtime (1f);
		g.SetActive (true);
		/*fps.enabled = true;
		cc.enabled = true;*/
		//Destroy (blurScript);
		Destroy (gameObject);
	}
}
