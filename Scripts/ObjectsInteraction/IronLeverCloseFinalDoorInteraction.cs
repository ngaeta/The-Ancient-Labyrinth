using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronLeverCloseFinalDoorInteraction :IronLeverBaseInteraction {

	public FinalDoorController door;
	public IAMonsterController iaMonster;
	public VisionMonsterTrigger vision;
	public LoadSecondLevel destroyScript;

	public float timeToLoadNextLevel= 3f, newFarCamera = 50f;
	public GameObject TriggerMonsterToActive;
	public Transform target;
	public GameManager gameManager;
	public AudioClip[] defaultAudioStep;
	public GameObject audioRain;
	public GameObject groundDestory;

	void Start() {
		OnStart ();
		m_IsLocked = false;
		FinalDoorController.onDoorClosed += LoadNextLevel;
	}
	#region implemented abstract members of IronLeverBaseInteraction

	public override void OnLeverDown ()
	{
		door.CloseDoor ();
	}

	public override void OnFinishLeverAnimation ()
	{
		
		TriggerMonsterToActive.SetActive (true);
		if (vision.PlayerSeen)
			iaMonster.Run (target);
		else
			iaMonster.RoarAndAfterRun (target);

		Destroy (groundDestory);
		Destroy (vision.gameObject);
		gameManager.ChangeDefaulStep (defaultAudioStep, defaultAudioStep [0]);
	}

	#endregion

	public void LoadNextLevel() {
		audioRain.SetActive (true);
		gameManager.ChangeCameraFar (newFarCamera);
		gameManager.ChangeDefaulStep (defaultAudioStep, defaultAudioStep [0]);
		destroyScript.DestroyGameObjects();
		StartCoroutine (LoadAsyncLevel ());
	}

	private IEnumerator LoadAsyncLevel() {
		yield return new WaitForSecondsRealtime (timeToLoadNextLevel);
		destroyScript.ActiveGameObjects ();
		Destroy (this);
	}

	void OnDisable() {
		FinalDoorController.onDoorClosed -= LoadNextLevel;
	}
}
