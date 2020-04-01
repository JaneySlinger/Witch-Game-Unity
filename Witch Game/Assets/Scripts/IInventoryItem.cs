using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryItem
{
    //any object that implements this interface will be able to be stored in the inventory
    string itemName {get;}
    Sprite itemImage {get;}
    void onPickup();
}

public class InventoryEventArgs: EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        this.item = item;
    }

    public IInventoryItem item;
}
