using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyOpener : MonoBehaviour
{
    public Inventory inventory;
    public bool inRange = false;

    public GameObject item_model;

    // Start is called before the first frame update
    void Start()
    {
        //register with the event handler
        inventory.IngredientUsed += Ingredient_ItemUsed;
    }


    void Ingredient_ItemUsed(object sender, IngredientEventArgs e){
        Debug.Log("the tag in the keyopener is " + e.tag);
        if(e.tag == "ingredient"){
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
