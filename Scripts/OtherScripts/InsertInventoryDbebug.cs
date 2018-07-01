using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertInventoryDbebug : MonoBehaviour {

	public Inventory inventory;
	public PickObjectInteraction[] objectToInsert;
	// Use this for initialization
	void Start () {
		foreach(PickObjectInteraction g in objectToInsert)
			inventory.Insert (g);
	}
}
