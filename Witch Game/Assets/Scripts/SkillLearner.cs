using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillLearner : MonoBehaviour
{
    public Inventory inventory;
    public string levitate_string;
    public string fire_string;
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
        //using the key string as it is stored between scenes
        Debug.Log(e.item.itemName);
        if(e.item.itemName == levitate_string){
            player.GetComponent<PlayerInteracter>().enabled = true;
        } else if(e.item.itemName == fire_string){
            player.GetComponent<FireSpell>().enabled = true;
        }
    }

}
