using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorysettings : MonoBehaviour {
    public Transform _InventoryPanel;
	// Use this for initialization
	void Start () {
        Inventory.InventoryPanel = _InventoryPanel;
	}
	
}
