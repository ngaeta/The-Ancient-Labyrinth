using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private Dictionary<PickObjectInteraction, int> m_Inventory;
	private List<PickObjectInteraction> m_ListInventory;
	public int maxCapacity=12;
	public InventoryLogicInteraction logic;

	void Awake() {
		m_Inventory = new Dictionary<PickObjectInteraction, int> ();
		m_ListInventory = new List<PickObjectInteraction> ();
	}

	public void Insert(PickObjectInteraction objects) {
		if (!m_Inventory.ContainsKey (objects)) {
			Debug.Log (objects.gameObject.name + " Insered ");
			logic.Add (objects);
			m_ListInventory.Add (objects);
			m_Inventory.Add (objects, 1);
		}
	}

	public bool Remove(PickObjectInteraction key) {
		if (m_Inventory.ContainsKey (key)) {
			logic.Remove (key);
			m_Inventory.Remove (key);
			m_ListInventory.Remove (key);
			return true;
		}
		return false;
	}

	public List<PickObjectInteraction> GetObjectsInInventory() {

		return m_ListInventory;
	}

	public int NumberOfObjectInInventory() {
		return m_Inventory.Count;
	}

	public bool IsInInventory(PickObjectInteraction objects) {	
		return m_Inventory.ContainsKey (objects);
	}
}
