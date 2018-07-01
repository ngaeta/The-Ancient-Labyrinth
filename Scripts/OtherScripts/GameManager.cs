using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {
	
	public delegate void Rain ();
	public static event Rain OnRainEvent;
	public int numberSphereToRain = 4;
	public UIManager ui;
	public FirstPersonController fps;
	public GameObject playerRain;
	public Camera mainCamera;
	public GameMusicScript gameMusic;
	public AudioClip newMusicDefault;

	private int m_SoulsSaved;

	private int m_SpherePicked;

	void Start() {
		AudioListener.pause = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		m_SpherePicked = 0;
		m_SoulsSaved = 0;
		mainCamera = Camera.main;
	}

	public void SpherePicked() {
		m_SpherePicked++;
		Debug.Log ("Sphere Picked " + m_SpherePicked);
		if (m_SpherePicked >= numberSphereToRain) {
			gameMusic.ChangeMusicDefault (newMusicDefault);
			if (OnRainEvent != null) {
				OnRainEvent ();  //vengono avvertiti tutti
			}
		}
	}

	public void LoadScene(string name) {
		
		if (ui.enabled) 
			ui.Pause ();
		AudioListener.pause = false;
		LoadMainLevel.sceneToLoad = name;
		SceneManager.LoadScene ("LoadingScene");
	}

	public void LoadSceneDirectly(string name) {
		AudioListener.pause = false;
		SceneManager.LoadScene (name);
	}

	public void ChangeDefaulStep(AudioClip[] newDefaultStep, AudioClip landStep) {
		fps.ChangeDefaultAudioStep (newDefaultStep, landStep);
	}

	public void StopRain() {
		playerRain.SetActive (false);
	}

	public void ChangeCameraFar(float newFar ) {
		mainCamera.farClipPlane = newFar;
	}

	public void SoulsSaved() {
		m_SoulsSaved++;
		Debug.Log ("Souls Saved: " + m_SoulsSaved);
	}

	public int GetSoulsSaved {
		get {
			return m_SoulsSaved;
		}
	}
}
