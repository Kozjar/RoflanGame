using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

    public Item ThisItem;
	public Transform item;
	void Start()
	{
		GetComponent<Button>().onClick.AddListener(delegate { ThisItem.AddItem(item); });
		
	}
	
}