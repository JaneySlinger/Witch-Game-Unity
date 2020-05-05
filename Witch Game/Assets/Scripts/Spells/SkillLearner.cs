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
    public PersistenceManager persistenceManager;


    

    // Start is called before the first frame update
    void Start()
    {
        //register with the event handler
        inventory.ItemUsed += Inventory_ItemUsed;
        //load whether the skills have been activated already
        if(persistenceManager.fireSpellKnown){
            LearnFireSpell();
        }
        if(persistenceManager.levitateSpellKnown){
            LearnLevitateSpell();
        }

    }

    void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        Debug.Log("SkillLeaner script registered event");
        //check if the correct item is in use
        //using the key string as it is stored between scenes
        Debug.Log(e.item.itemName);
        if(e.item.itemName == levitate_string){
            LearnLevitateSpell();
        } else if(e.item.itemName == fire_string){
            LearnFireSpell();
        }
    }

    void LearnFireSpell(){
        player.GetComponent<FireSpell>().enabled = true;
        persistenceManager.SetFireSpell(true);
    }

    void LearnLevitateSpell(){
        player.GetComponent<PlayerInteracter>().enabled = true;
        persistenceManager.SetLevitateSpell(true);
    }

}
