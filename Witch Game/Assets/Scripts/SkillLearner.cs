using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillLearner : MonoBehaviour
{
    public Inventory inventory;
    public GameObject key;
    private GameObject item;
    public GameObject player;


    

    // Start is called before the first frame update
    void Start()
    {
        //register with the event handler
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        Debug.Log("SkillLeaner script registered event");
        //check if the correct item is in use
        item = (e.item as MonoBehaviour).gameObject; 
        if(item == key)
        { 
            player.GetComponent<PlayerInteracter>().enabled = true;
            
        }
    }

}
