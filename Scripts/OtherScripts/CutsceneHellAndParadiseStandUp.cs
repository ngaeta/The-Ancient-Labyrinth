using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class CutsceneHellAndParadiseStandUp : MonoBehaviour {

	public Blur blurScript;
	public GameObject UI;
	public UIManager UIManager;
	public Animator anim;
	public float timeToModifyBlur=1f;
	public GameObject fpsGameObject;
	public AudioSource music;

	public delegate void AnimationHalfTime();
	public event AnimationHalfTime OnAnimationHalfTimeEvent;

	void Start() {
		blurScript.enabled = true;
		UIManager.enabled = false;
		UI.SetActive (false);
		anim.enabled = true;
		StartCoroutine (StartBlurAnimation ());
	}
	
	private IEnumerator StartBlurAnimation() {
		while (blurScript.iterations != 0) {
			yield return new WaitForSecondsRealtime (timeToModifyBlur);
			blurScript.iterations--;
		}
		blurScript.enabled = false;
	}

	public void AnimationFinished() {
		music.Play ();
		UI.SetActive (true);
		UIManager.enabled = true;
		fpsGameObject.SetActive (true);
		Destroy (gameObject);
	}

	public void AnimationHalf() {
		if (OnAnimationHalfTimeEvent != null)
			OnAnimationHalfTimeEvent();
	}
}
