using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceFinalPlayerInteraction : MonoBehaviour, ObjectInteraction {

	public SoulsPlayerController soulsCutscene;
	public CutscenesController cutsceneController;
	public GameObject waterFinal;
	public bool m_IsEmpty = true;
	public AudioSource audio2D;
	public AudioClip clipDrinking;
	public float delayToStartRitual = 2f;

	void Start() {
		//m_IsEmpty = true;
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		if (!m_IsEmpty) {
			cutsceneController.StartCutscene ();
			audio2D.clip=clipDrinking;
			audio2D.Play ();
			Destroy (waterFinal);
			gameObject.layer = LayerMask.NameToLayer ("Default");
			StartCoroutine (WaitToStartCutscenes ());
		}
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion

	public bool IsEmpty {
		set {
			m_IsEmpty = value;
		}
	}

	private IEnumerator WaitToStartCutscenes() {
		yield return new WaitForSecondsRealtime (clipDrinking.length + delayToStartRitual);
		soulsCutscene.gameObject.SetActive (true);
		soulsCutscene.PlayCutscene ();
		Destroy (this);
	}
}
