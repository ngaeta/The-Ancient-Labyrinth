using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ZombieGrabPlayerCutscene : MonoBehaviour {

	public CutscenesController cutscenesController;
	public ZombieMummyController zombie;
	public VignetteAndChromaticAberration vignetteScript;
	public AudioVoiceController voicePlayer;
	public AudioClip clipScreamPlayer, clipBreathingPlayer;
	public Blur blurScript;
	public GameMusicScript gameMusicScript;
	public GameObject[] objectToDestroy;

	public float timeToWaitToOpenEye = 4f;
	public float timeToUpdateVignette = 0.2f;
	public float timeToRetunMovePlayer = 4f;
	public float quantityUpdateWignette = 0.1f;
	public float sogliaIntensityVignetteToStop = 0.3f;

	public void StartCutscene() {
		cutscenesController.stopTorch = false;
		cutscenesController.StartCutscene ();
		zombie.Attack ();
		voicePlayer.Play (clipScreamPlayer);
		vignetteScript.enabled = true;
		vignetteScript.intensity = 1f;
		blurScript.enabled = true;
		gameMusicScript.Stop ();
		DestroyObjects ();
		StartCoroutine (WaitToReturnLogicGame ());
	}

	private IEnumerator WaitToReturnLogicGame() {
		yield return new WaitForSecondsRealtime (timeToWaitToOpenEye);
		voicePlayer.Play (clipBreathingPlayer);
		Destroy (zombie.gameObject);  //after because the zombie audio must to finish
		while (vignetteScript.intensity > sogliaIntensityVignetteToStop) {
			yield return new WaitForSecondsRealtime (Time.deltaTime * timeToUpdateVignette);
			vignetteScript.intensity = Mathf.Lerp (vignetteScript.intensity, 0f, quantityUpdateWignette);
			Debug.Log (vignetteScript.intensity);
		}
		vignetteScript.enabled = false;
		yield return new WaitForSecondsRealtime (timeToRetunMovePlayer);
		blurScript.enabled = false;
		cutscenesController.StopCutscene ();
		cutscenesController.stopTorch = true;
		Destroy (gameObject);
	}

	private void DestroyObjects() {
		foreach (GameObject g in objectToDestroy)
			Destroy (g);
	}
}
