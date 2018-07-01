using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectInteraction : MonoBehaviour, ObjectInteraction {

	public Inventory inventoryScript;
	public Sprite imageItem;
    public string textObject;

	public delegate void PickObjectAction ();
	public event PickObjectAction OnPickObject;

	public virtual void OnClick() {
		inventoryScript.Insert (this);
		if (OnPickObject != null)
			OnPickObject ();
		gameObject.SetActive (false);  // con destroy creava problemi quando utilizzavamo i riferimenti per usare gli oggetti nell inventario
	}

	public  void OnRelease() {
	}
	public  void OnHeld() {
	}

    public string getTextObject()
    {
        return textObject;
    }
    public void ChangeTextObject(string newText)
    {
        textObject = newText;
    }
}
