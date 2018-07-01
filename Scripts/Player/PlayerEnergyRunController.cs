using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerEnergyRunController : MonoBehaviour {

	private int m_PlayerEnergy;
	private bool m_HasEnergyToRun;
	private bool m_OnRecoveryEnergy;
	private bool m_WaitToNextControl;

	//public IAMonsterController ia;
	public FirstPersonController fpsController;
	public int MinEnergyToRun = 4;
	public int MaxPlayerEnergy = 8;
	public AudioVoiceController audioBreath;
	public AudioClip clipBreath;

	// Use this for initialization
	void Start () {
		m_PlayerEnergy = MaxPlayerEnergy;
		m_HasEnergyToRun = true;
		m_OnRecoveryEnergy = false;
		m_WaitToNextControl = false;
	}
		
	void Update() {
		//Debug.Log (m_PlayerEnergy);
		if (!fpsController.IsStopped && Input.GetKey (KeyCode.LeftShift)) {
			if (m_HasEnergyToRun) {
				StopCoroutine ("RecoveryEnergy");
				m_OnRecoveryEnergy = false;
				fpsController.m_IsWalking = false;
				if (!m_WaitToNextControl) {
					m_WaitToNextControl = true;
					StartCoroutine (ControlEnergy ());
				}
			} else
				fpsController.m_IsWalking = true;
		} else  {
			fpsController.m_IsWalking = true;
			if(!m_OnRecoveryEnergy)
				StartCoroutine ("RecoveryEnergy");
		}
	}

	public IEnumerator ControlEnergy() {
		if (m_PlayerEnergy > 0) {
			m_PlayerEnergy--;
			yield return new WaitForSecondsRealtime (1f);
			m_WaitToNextControl = false;
		} else {
			EnergyFinished ();
			m_WaitToNextControl = false;
		}
	}

	private void EnergyFinished() {
		m_HasEnergyToRun = false;
		m_PlayerEnergy = 0;
		audioBreath.Play (clipBreath);
		StartCoroutine ("RecoveryEnergy");
	}

	public IEnumerator RecoveryEnergy() {
		m_OnRecoveryEnergy = true;
		while (m_PlayerEnergy < MaxPlayerEnergy) {
			yield return new WaitForSeconds (0.5f);
			m_PlayerEnergy++;
			if (m_PlayerEnergy >= MinEnergyToRun)
				m_HasEnergyToRun = true;
		}
		m_PlayerEnergy = MaxPlayerEnergy;
		m_OnRecoveryEnergy = false;
	}
}
