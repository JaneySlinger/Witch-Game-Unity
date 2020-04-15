using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    
    public GameObject cauldron;

    public HUDManager manager;
    public PersistenceManager persistenceManager;
    public List<IInventoryItem> items = new List<IInventoryItem>();


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
    
        //broadcast event to keyopener and HUDManager
        if(ItemUsed != null)
        {   
            if((item.tag == "ingredient" && cauldron.GetComponent<KeyOpener>().inRange) || item.tag == "book"){
                Debug.Log("Inventory broadcasting event");
            ItemUsed.Invoke(this, new InventoryEventArgs(item));
            } else {
                Debug.Log("not in range to use item");
                manager.SetNotificationText("You can't use that here.");
            }
            
        }
        items.Remove(item);


    }

    private void Start() {
        //load in the inventory from the other scene
        items = persistenceManager.storedItems;
        
    }
    


}
