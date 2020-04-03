using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    //public event EventHandler<InventoryEventArgs> ItemRemoved;  //event to the HUD to remove the ingredient
    List<IInventoryItem> items = new List<IInventoryItem>();


    public void addItem(IInventoryItem item)
    {
        //checking if the item is already in the list prevents the double pick-ups that were occurring
        Debug.Log("Inventory addItem");
        if(!items.Contains(item)){
            items.Add(item);
            item.onPickup();

            //broadcast event to the hud
            if(ItemAdded != null)
            {
                ItemAdded.Invoke(this, new InventoryEventArgs(item));
            }
        } 
        
    }

    public void useItem(IInventoryItem item)
    {
    
        //broadcast event to the cauldron
        if(ItemUsed != null)
        {
            Debug.Log("Inventory broadcasting event");
            ItemUsed.Invoke(this, new InventoryEventArgs(item));
            //ItemRemoved.Invoke(this,new InventoryEventArgs(item));
        }
        items.Remove(item);


    }
    


}
