﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
	// Имя нашего предмета.
	public string name = null;
	// Количество предметов(для стакающих).
	public int count;
	public bool IsStackable = false;
	// Описание предмета(в коде пока не реализованно).
	[Multiline(5)]
	public string Description;
    // Панель с кнопками(слотами).
    //public Transform InventoryPanel;
    public Transform PrefabItem;


    // Функция проверяющая на тип предмета.
    public void AddItem()
	{
		if (IsStackable == true)
		{
			AddStackableItem();
		}
		else
		{
			AddNotStackableItem();
		}
	}
	// Функция добавляющаа стакающий предмет в инвентарь.
	public void AddStackableItem()
	{
		bool FoundItem = false;
		for(int i=0;i<Inventory.currentSlot;i++)
		{
			
				if (Inventory._inventory[i].name == name)
				{
					Inventory._inventory[i].count++;
					Inventory.InventoryPanel.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text = Inventory._inventory[i].count.ToString();
					FoundItem = true;
					break;


				}
			
		

		}
		if(!FoundItem)
		{
			Object.Instantiate(PrefabItem, Inventory.InventoryPanel.GetChild(Inventory.currentSlot));
			Inventory._inventory[Inventory.currentSlot] = this;

			count++;
            Inventory.InventoryPanel.GetChild(Inventory.currentSlot).GetChild(0).GetChild(0).GetComponent<Text>().text = count.ToString();
			Inventory.currentSlot++;
		}
	}
	// Функция добавляющая нестакающий предмет в инвентарь.
	private void AddNotStackableItem()
	{
		// Проверка на пустоту слота(ячейки).
		//bool EmprtySlot=false;
		for (int i = 0; i <= 14; i++)
		{
			// Если i-ый элемент не существует то...
			if (Inventory._inventory[i] == null)
			{
				// Добавляем предмет в пустой слот.
				Object.Instantiate(PrefabItem, Inventory.InventoryPanel.GetChild(i));
				// Записываем этот предмет в массив класса.
				Inventory._inventory[i] = this;
				//EmprtySlot = true;
				// Ломаем нахуй код.
				break;

			}
		}
		// Код ниже думаю понятен.
		//if (EmprtySlot==false)
		//{
		//	Object.Instantiate(PrefabItem, InventoryPanel.GetChild(Inventory.currentSlot));
		//	Inventory._inventory[Inventory.currentSlot] = this;
		//	Inventory.currentSlot++;
		//}
	}
	//public bool FindItem(string Name)
	//{
	//	foreach(var index in Inventory._inventory)
	//	{
	//		if (index.name == Name)
	//			return true;
	//		else
	//			return false;
	//	}
	//	return;
	//}
}







































//public class Item : MonoBehaviour
//{
//	public inventory Inventory;
//	public Transform RedSword, BlueSword, Letter, CloseButton;
//	public Transform RedSwordPrefab, BlueSwordPrefab, LetterPrefab;
//	public KeyCode ShowInventory;
//	public Transform LetterPanel;
//	public string LetterText;
//	private int a = 0;

//	private void Start()
//	{
//		RedSword.GetComponent<Button>().onClick.AddListener(delegate { Inventory.addNewItem(RedSwordPrefab.gameObject); });
//		BlueSword.GetComponent<Button>().onClick.AddListener(delegate { Inventory.addNewItem(BlueSwordPrefab.gameObject); });
//		Letter.GetComponent<Button>().onClick.AddListener(delegate { Inventory.addNewItem(LetterPrefab.gameObject); });
//		CloseButton.GetComponent<Button>().onClick.AddListener(delegate { CloseLetterText(LetterPanel); });







//	}

//	private void Update()
//	{
//		if (Input.GetKeyDown(ShowInventory))
//		{

//			if (Inventory._Inventory.gameObject.activeSelf)
//			{
//				Inventory._Inventory.gameObject.SetActive(false);

//			}
//			else
//				Inventory._Inventory.gameObject.SetActive(true);
//		}

//		for (int i = 0; i < Inventory.NextSlot; i++)
//		{
//			if (Inventory.IsItemInSlot(Inventory._Inventory.GetChild(i), "Letter"))
//			{
//				Inventory._Inventory.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { ShowLetterText(LetterPanel); });
//			}
//		}

//	}

//	void OnTriggerEnter2D(Collider2D collider)
//	{

//		bool OpenedDoor = false;
//		for (int i = 0; i < Inventory.NextSlot; i++)
//		{


//			if (collider.gameObject.tag == "Player" && Inventory.IsItemInSlot(Inventory._Inventory.GetChild(i), "RedSword"))

//			{
//				OpenedDoor = true;
//				break;
//			}
//		}
//		if (OpenedDoor)
//			Debug.Log("Дверь открыта");
//		else
//			Debug.Log("Нет ключа");
//	}

//	void ShowLetterText(Transform panel)
//	{

//		panel.gameObject.SetActive(true);
//		panel.GetChild(0).GetComponent<Text>().text = LetterText;


//	}

//	void CloseLetterText(Transform panel)
//	{
//		panel.gameObject.SetActive(false);
//	}
//}

//[System.Serializable]
//public class inventory
//{
//	public Transform _Inventory;
//	[HideInInspector]
//	public int NextSlot;
//	//public item[] _item = new item[8];


//	public bool IsItemInSlot(Transform slot, string Name)
//	{
//		if (slot.GetChild(0).GetComponent<ItemInfo>().ThisItem.name == Name)
//			return true;
//		else
//			return false;

//	}

//	public void addNewItem(GameObject PrefabItem)
//	{
//		item _Item = PrefabItem.GetComponent<ItemInfo>().ThisItem;
//		bool ThisIsNewItem = true;
//		for (int i = 0; i < NextSlot; i++)
//		{
//			Transform ItemInSlot = _Inventory.GetChild(i).GetChild(0);

//			//if(IsItemInSlot(ItemInSlot,_Item.name))
//			if (_Item.name == ItemInSlot.GetComponent<ItemInfo>().ThisItem.name)
//			{
//				ItemInSlot.GetComponent<ItemInfo>().ThisItem.count++;
//				ItemInSlot.GetChild(0).GetComponent<Text>().text = ItemInSlot.GetComponent<ItemInfo>().ThisItem.count.ToString();
//				ThisIsNewItem = false;
//				break;
//			}


//		}

//		if (ThisIsNewItem)
//		{
//			Item.Instantiate(PrefabItem, _Inventory.GetChild(NextSlot));
//			NextSlot++;
//			//Instantiate(PrefabItem, _Inventory.GetChild(NextSlot));
//		}


//	}
//	public void AddItem()
//	{
//		if (Is == true)
//			AddCountableItem();
//		Else
//AddNonCountableItem();
//	}


//	public void addNewItemUnStackable(GameObject PrefabItem)
//	{
//		item _Item = PrefabItem.GetComponent<ItemInfo>().ThisItem;
//	}
//}

//[System.Serializable]
//public class item
//{
//	public string name;
//	[HideInInspector]
//	public int count;
//	public bool IsStackable = false;
//	[Multiline(5)]
//	public string Description;

//}

