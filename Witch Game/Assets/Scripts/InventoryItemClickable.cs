﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemClickable : MonoBehaviour
{
    public GameObject cauldron;

    public IInventoryItem item;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnItemClicked()
    {
        if(item!= null)
        {
            //check if the item is in range to be used
            if(cauldron.GetComponent<KeyOpener>().inRange){
                Debug.Log("Using: " + item.itemName);
                inventory.useItem(item);
            }
        }
    }
}
