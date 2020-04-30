//implements IInventoryItem interface
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour, IInventoryItem
{
    public Sprite _itemImage;
    public string _itemName;
    public string _tag;
    public string _description;
    public GameObject player;
    public int ingredientNumber;
    public PersistenceManager persistenceManager;


    public string itemName
    {
        get
        {
            return _itemName;
        }
    }

    public Sprite itemImage
    {
        get
        {
            return _itemImage;
        }
    }

    public string tag
    {
        get
        {
            return _tag;
        }
    }

        public string description
    {
        get
        {
            return _description;
        }
    }

    public void onPickup()
    {
        if(ingredientNumber == 1){
            persistenceManager.ingredientOneCollected = true;
        } else if(ingredientNumber == 2){
            persistenceManager.ingredientTwoCollected = true;
        } else if(ingredientNumber == 3){
            persistenceManager.ingredientThreeCollected = true;
        }
        gameObject.SetActive(false); // "picking up merely makes it invisible"        

    }

}
