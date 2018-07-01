using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalicePickInteraction : PickObjectInteraction {

	private bool m_IsEmpty;

	void Start() {
		m_IsEmpty = true;
	}

	public bool IsEmpty {
		get {
			return m_IsEmpty;
		}
		set {
			m_IsEmpty = value;
		}
	}
}
