﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyOpener : MonoBehaviour
{
    public Inventory inventory;
    public bool inRange = false;
    public GameObject ingredientOne;
    public GameObject ingredientTwo;
    public GameObject ingredientThree;

    private GameObject item;
    public GameObject item_model;


    

    // Start is called before the first frame update
    void Start()
    {
        //register with the event handler
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        Debug.Log("KeyOpener script registered event");
        //check if the correct item is in use
        item = (e.item as MonoBehaviour).gameObject; 
        if(item == ingredientOne || item == ingredientTwo || item == ingredientThree)
        { 
            gameObject.GetComponent<Potion>().AddIngredient(item_model);
   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}
