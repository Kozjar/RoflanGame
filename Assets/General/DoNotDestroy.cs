using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {
	public Transform InventoryPanel;

	void Start () {
		DontDestroyOnLoad(InventoryPanel);
	}
	

}
