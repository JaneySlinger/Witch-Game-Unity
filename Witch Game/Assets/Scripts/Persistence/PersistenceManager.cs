using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PersistenceManagerData", menuName = "ScriptableObjects/PersistenceManager", order = 1)]

public class PersistenceManager : ScriptableObject
{
    public bool fireSpellKnown;
    public bool levitateSpellKnown; 
    public int ingredients_submitted; //not done yet
    public List<IInventoryItem> storedItems = new List<IInventoryItem>();
    public List<GameObject> levitateItems = new List<GameObject>();

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

    public void SetObjectPositions(List<GameObject> objects){
        foreach (GameObject item in objects)
        {
            Debug.Log(item.transform);
            Debug.Log(item.layer);
        }
    }
}
