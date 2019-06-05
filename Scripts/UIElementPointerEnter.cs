using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementPointerEnter : MonoBehaviour {

	public Color color;

	private Image image;
	private Color defaultColor;

	void Start() {
		
		image = GetComponent<Image> ();
		defaultColor = image.color;
	}

	public void ColorPointerEnter() {
		image.color = color;
	}

	public void ColorPointerExit() {
		image.color = defaultColor;
    }

    void OnDisable() {
		ColorPointerExit ();
	}
}
