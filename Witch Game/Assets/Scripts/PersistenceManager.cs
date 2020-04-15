using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PersistenceManagerData", menuName = "ScriptableObjects/PersistenceManager", order = 1)]

public class PersistenceManager : ScriptableObject
{
    public bool fireSpellKnown;
    public bool levitateSpellKnown;
    //public string[] inventory;
    public int ingredients_submitted;
    public List<IInventoryItem> storedItems = new List<IInventoryItem>();


    public void SetFireSpell(bool value){
        fireSpellKnown = value;
    }

    public void SetLevitateSpell(bool value){
        levitateSpellKnown = value;
    }

    public void SetInventory(List<IInventoryItem> items){
        Debug.Log("copying the list");
        storedItems = items;         
    }
}
