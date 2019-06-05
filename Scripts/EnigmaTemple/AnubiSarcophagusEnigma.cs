using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiSarcophagusEnigma : MonoBehaviour {

	public delegate void EnigmaStatus ();
	public static event EnigmaStatus OnEnigmaResolved, OnEnigmaWrong;
	public GemInteractionEnigma[] OrderToResolveEnigma;
    public float TimeToOffParticles = 10f;

	private List<GemInteractionEnigma> m_GemSwitched;
    private float currTimeToOff;

	void Start() {
		m_GemSwitched = new List<GemInteractionEnigma> ();
        currTimeToOff = TimeToOffParticles;
	}

	public void GemSwitched(GemInteractionEnigma gem) {
		
		m_GemSwitched.Add(gem);
        currTimeToOff = TimeToOffParticles;

		if (m_GemSwitched.Count == OrderToResolveEnigma.Length) 
		{
			bool enigmaResolved = ControlEnigma ();
			if (enigmaResolved) {
				if(OnEnigmaResolved != null)
					OnEnigmaResolved ();
                Destroy(this);
			}
		}
	}

    void Update()
    {
        if(m_GemSwitched.Count > 0)
        {
            if (currTimeToOff <= 0)
            {
                if (OnEnigmaWrong != null)
                    OnEnigmaWrong();
                m_GemSwitched.Clear();
            }
            else
                currTimeToOff -= Time.deltaTime;
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
