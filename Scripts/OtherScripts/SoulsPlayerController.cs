using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class SoulsPlayerController : MonoBehaviour {

	public Animator GoodSoul, EvilSoul;
	public string triggerNameGood = "Good";
	public string triggerNameEvil = "Evil";
	public CutscenesController cutscenesScript;
	public Blur blur;
	public AudioVoiceController audioPlayer;
	public AudioClip clipVoice;
	public float timeToActiveRitual;
	public SoulsRitualAnimationController s;
	public ScaleBalanceController scaleBalance;
	public GameObject chaliceToTake;
	public Transform playerHand;

	public void PlayCutscene() {
		cutscenesScript.stopTorch = true;
		cutscenesScript.StartCutscene ();
		StartCoroutine (WaitToRitual ());
	}

	private IEnumerator WaitToRitual() {
		yield return new WaitForSecondsRealtime (timeToActiveRitual);
		s.StartAnimation ();
		audioPlayer.Play (clipVoice);
		GoodSoul.gameObject.SetActive (true);
		EvilSoul.gameObject.SetActive (true);
		GoodSoul.SetTrigger (triggerNameGood);
		EvilSoul.SetTrigger (triggerNameEvil);
		Invoke ("Stop", clipVoice.length - 2f);
	}

	private void Stop() {
		s.stopBlur = true;
		cutscenesScript.StopCutscene ();
		scaleBalance.ControlBalance ();
		Destroy (this);
	}

	public void TakeChalice() {
		chaliceToTake.transform.parent = playerHand;
	}
}
