using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour {

	private List<PickObjectInteraction> m_Inventory;
	private int m_NextItem = 0;
	public Sprite defaultSprite;
	private bool AlreadyEnabled = false;

	public Inventory inventory;
	public Image[] item;

	void OnEnable() {
		UpdateInventory ();
	}

	void OnDisable() {
		ClearInventory ();
	}

	void Update() {
		if (m_NextItem != inventory.NumberOfObjectInInventory ()) {
			ClearInventory ();
			UpdateInventory ();
		}
	}

	private void UpdateInventory() {
		m_Inventory = inventory.GetObjectsInInventory ();
		foreach (PickObjectInteraction objectInventory in m_Inventory) {
			item [m_NextItem].sprite = objectInventory.imageItem;
			m_NextItem++;
		}
	}

	private void ClearInventory() {
		m_NextItem = 0;
		foreach (Image i in item)
			i.sprite = defaultSprite;
	}
}
