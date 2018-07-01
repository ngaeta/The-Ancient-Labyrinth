using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolInteraction :MonoBehaviour,  ObjectInteraction {

	public SymbolEnigma enigma;

	public float nextClick = 0.5f;
	private bool m_NextClick;

	void Start() {
		m_NextClick = true;
	}

	private IEnumerator WaitNextClick() {
		yield return new WaitForSecondsRealtime (nextClick);
		m_NextClick = true;
	}

	#region ObjectInteraction implementation

	public void OnClick ()
	{	

		if (m_NextClick) {
			m_NextClick = false;
			enigma.SymbolPressed (this);
			StartCoroutine (WaitNextClick ());
		}
	}

	public void OnRelease ()
	{
		
	}

	public void OnHeld ()
	{
		
	}

	#endregion
}
