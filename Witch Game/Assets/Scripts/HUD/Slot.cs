﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public IInventoryItem item;
    public Inventory inventory;

    public void OnItemClicked()
    {
        if(item != null)
        {
            Debug.Log("Using:" + item.itemName);
            inventory.useItem(item);
        }
    }
}
