using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public Item ThisItem;

    public void AddThisItem()
    {
        ThisItem.AddItem();
    }
}