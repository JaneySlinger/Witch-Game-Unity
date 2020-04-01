using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpener : MonoBehaviour
{
    public Inventory inventory;
    public bool inRange = false;
    public GameObject key;

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
        if((e.item as MonoBehaviour).gameObject == key)
        {
            //check if in range
            if(inRange)
            {
                gameObject.GetComponent<Potion>().AddIngredient();
            }
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
