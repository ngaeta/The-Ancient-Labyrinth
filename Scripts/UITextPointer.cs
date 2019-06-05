using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextPointer : MonoBehaviour {

	public Color color;
	private Text text;
	private Color defaultColor;

	void Start() {
		text = GetComponent<Text> ();
		defaultColor = text.color;
	}

	public void ColorPointerEnter() {
		text.color = color;
	}

	public void ColorPointerExit() {
		text.color = defaultColor;
	}

	void OnDisable() {
		ColorPointerExit ();
	}
}
