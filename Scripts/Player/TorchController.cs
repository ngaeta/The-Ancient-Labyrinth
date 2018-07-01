using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TorchController : MonoBehaviour {

	private Animator m_Animator;
	private int m_HashTorchIsOnTrigger;
	public GameObject torch;
	public VisionMonsterTrigger vision;
	[SerializeField] private string stringTorchTrigger = "TorchIsOn";

	void Start() {
		m_Animator = GetComponent<Animator> ();
		m_HashTorchIsOnTrigger = Animator.StringToHash (stringTorchTrigger);
	}

	public void SwitchTorch() {
		bool value = !m_Animator.GetBool (m_HashTorchIsOnTrigger);
		torch.SetActive (value);
		m_Animator.SetBool (m_HashTorchIsOnTrigger, value);
		if (vision != null && vision.enabled) {  //vedere in caso di problemi, cambiare con vision.enabled
			if (!value)
				vision.ReduceVisibility ();
			else
				vision.AddVisibility ();
		}
		
	}


}
