using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryItem
{
    //any object that implements this interface will be able to be stored in the inventory
    string itemName {get;}
    Sprite itemImage {get;}
    string tag {get;}
    string description {get;}
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

public class IngredientEventArgs: EventArgs{
    public IngredientEventArgs(String tag, Sprite itemImage){
        this.tag = tag;
        this.itemImage = itemImage;

    }

    public String tag;
    public Sprite itemImage;
}
