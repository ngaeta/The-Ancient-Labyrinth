using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolEnigma : MonoBehaviour {

	public IronFenceController fence;
	public SymbolInteraction[] passwordSymbol;
	public GameObject triggerToDestroy;

	private List<SymbolInteraction> symbolsPressed;

	void Start() {
		symbolsPressed = new List<SymbolInteraction> ();
	}

	public void SymbolPressed(SymbolInteraction symbol) {
		if (!symbolsPressed.Contains (symbol))
			symbolsPressed.Add (symbol);
		else
			symbolsPressed.Remove (symbol);
		if (symbolsPressed.Count == passwordSymbol.Length)
			ControlEnigma ();
	}

	private void ControlEnigma() {
		foreach (SymbolInteraction s in passwordSymbol) {
			if (!symbolsPressed.Contains (s)) {
				Debug.Log ("Diverso");
				return;
			}
		}
		fence.LoverFence ();
		Destroy (triggerToDestroy);
		Destroy (this);
	}
}
