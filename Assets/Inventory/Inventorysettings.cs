using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorysettings : MonoBehaviour {
    public Transform _InventoryPanel;
    public  Transform NoficationsContent;
    public  Transform NotificationItemPenel_Prefab;
    // Use this for initialization
    void Start () {
        Inventory.InventoryPanel = _InventoryPanel;
        Inventory.NoficationsContent = NoficationsContent;
        Inventory.NotificationItemPenel_Prefab = NotificationItemPenel_Prefab;
	}
	
}
