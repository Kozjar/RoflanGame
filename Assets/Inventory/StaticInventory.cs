using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventory : MonoBehaviour {

    public bool FindItemWithName(string name)
    {
        for (int i = 0; i <= 14; i++)
        {
            try
            {
                // Если i-ый элемент не существует то...
                if (Inventory._inventory[i].name == name)
                {
                    return true;
                }
            }
            catch { }
        }
        return false;
    }

    public bool FindItemWithName(string name, ref int index)
    {
        for (int i = 0; i <= 14; i++)
        {
            try
            {
                // Если i-ый элемент не существует то...
                if (Inventory._inventory[i].name == name)
                {
                    index = i;
                    return true;
                }
            }
            catch { }
        }
        return false;
    }

    public void DeleteItemWithName(string name)
    {
        int index = 0;
        if (FindItemWithName(name, ref index))
        {
            Transform slot = Inventory.InventoryPanel.GetChild(index).GetChild(0);
            Inventory._inventory[index] = null;
            GameObject.Destroy(slot.gameObject);
        }
        else
            Debug.Log("Предмета с таким именем нет");
    }
}

public static class Inventory
{
    public static Item[] _inventory = new Item[14];
    public static int currentSlot = 0;
    public static Transform InventoryPanel;

    public static bool FindItemWithName(string name)
    {
        for (int i = 0; i <= 14; i++)
        {
            try
            {
                // Если i-ый элемент не существует то...
                if (Inventory._inventory[i].name == name)
                {
                    return true;
                }
            }
            catch { }
        }
        return false;
    }

    public static bool FindItemWithName(string name, ref int index)
    {
        for (int i = 0; i <= 14; i++)
        {
            try
            {
                // Если i-ый элемент не существует то...
                if (Inventory._inventory[i].name == name)
                {
                    index = i;
                    return true;
                }
            }
            catch { }
        }
        return false;
    }

    public static void DeleteItemWithName(string name)
    {
        int index = 0;
        if (FindItemWithName(name, ref index))
        {
            Transform slot = Inventory.InventoryPanel.GetChild(index).GetChild(0);
            Inventory._inventory[index] = null;
            GameObject.Destroy(slot.gameObject);
        }
        else
            Debug.Log("Предмета с таким именем нет");
    }
}
