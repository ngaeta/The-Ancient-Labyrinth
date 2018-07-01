using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryLogicInteraction : MonoBehaviour {

	public MouseCursor m;
	public Dictionary <Sprite, PickObjectInteraction> dictionaryInventory;
	public Inventory inventory;
	public UIManager ui;

	void Awake() {
		dictionaryInventory = new Dictionary<Sprite, PickObjectInteraction> ();
	}
		
	public void OnClick (Image imageClicked)
	{
		if (m != null && m.OverObject != null) {
			ObjectInventoryInteraction obj = m.OverObject.GetComponent<ObjectInventoryInteraction> ();
			if (obj != null) {
				PickObjectInteraction pickObject;
				dictionaryInventory.TryGetValue (imageClicked.sprite, out pickObject); 
				if (pickObject != null) {
					obj.UseObject (pickObject);
					ui.ShowInventory ();
				}
			}
		}

	}

	public void Add(PickObjectInteraction objectPicked) {
		Debug.Log (objectPicked.imageItem.name);
		if (!dictionaryInventory.ContainsKey (objectPicked.imageItem)) {
			dictionaryInventory.Add (objectPicked.imageItem, objectPicked);
			Debug.Log (objectPicked.imageItem.name + " added ");
		}

		//DebugInventory ();
	}

	public void Remove(PickObjectInteraction objectToRemove) {
		if (dictionaryInventory.ContainsKey (objectToRemove.imageItem))
			dictionaryInventory.Remove (objectToRemove.imageItem);
	}

	private void DebugInventory() {
		Dictionary<Sprite, PickObjectInteraction>.KeyCollection k = dictionaryInventory.Keys;
		foreach (Sprite s in k) {
			PickObjectInteraction o;
			dictionaryInventory.TryGetValue (s, out o);
			Debug.Log ("chiave " + s.name + " valore " + o.name);
		}
	}

    public PickObjectInteraction GetObject(Image imageToControl)
    {
        PickObjectInteraction pickObject;
        dictionaryInventory.TryGetValue(imageToControl.sprite, out pickObject);
        return pickObject;
    }
}
