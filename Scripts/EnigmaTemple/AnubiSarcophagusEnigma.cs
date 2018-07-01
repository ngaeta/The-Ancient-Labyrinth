using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiSarcophagusEnigma : MonoBehaviour {

	public delegate void EnigmaStatus ();
	public static event EnigmaStatus OnEnigmaResolved, OnEnigmaWrong;
	public GemInteractionEnigma[] OrderToResolveEnigma;
	private List<GemInteractionEnigma> m_GemSwitched;

	void Start() {
		m_GemSwitched = new List<GemInteractionEnigma> ();
	}

	public void GemSwitched(GemInteractionEnigma gem) {
		
		m_GemSwitched.Add(gem);

		if (m_GemSwitched.Count == OrderToResolveEnigma.Length) 
		{
			bool enigmaResolved = ControlEnigma ();
			if (enigmaResolved) {
				if(OnEnigmaResolved != null)
					OnEnigmaResolved ();
			}
			else {
				if(OnEnigmaWrong != null)
					OnEnigmaWrong ();
				m_GemSwitched.Clear ();
			}
		}
	}

	private bool ControlEnigma() {
	
		for(int next = 0; next<OrderToResolveEnigma.Length; next++) {
			if (m_GemSwitched [next].gameObject != OrderToResolveEnigma [next].gameObject)
				return false;
		}

		return true;
	}

	public void StartOnEnigmaWrong() {
		if (OnEnigmaWrong != null)
			OnEnigmaWrong ();
	}
}
