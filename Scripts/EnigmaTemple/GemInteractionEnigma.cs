using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInteractionEnigma : MonoBehaviour, ObjectInteraction {

	public AnubiSarcophagusEnigma enigma;
	public AnubiStatueEyeController anubiEye;
	public GemParticleInteraction particle;
	public GemAudioInteraction audioGem;
	public float timeToTurnOffFlame = 1.5f;

	private bool m_IsAlreadyClicked;

	// Use this for initialization
	void Start () {
		m_IsAlreadyClicked = false;
		AnubiSarcophagusEnigma.OnEnigmaWrong += SwitchOff;
	}
		
	public void SwitchOff() {
		StartCoroutine (WaitSeconds ());
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{
		if (!m_IsAlreadyClicked) {
			m_IsAlreadyClicked = true;
			particle.SwitchParticle ();
			audioGem.FlameOn ();
			enigma.GemSwitched (this);
			anubiEye.GemSwitched (this);
		}
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion

	private IEnumerator WaitSeconds() {
		yield return new WaitForSecondsRealtime (timeToTurnOffFlame);
		particle.SwitchParticle ();
		m_IsAlreadyClicked = false;
	}

}
