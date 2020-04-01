using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        //when started register with the event handler of the inventory
        inventory.ItemAdded += InventoryItemAdded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //event handler for an item being added
    private void InventoryItemAdded(object sender, InventoryEventArgs e)
    {
        Transform panel = transform.Find("InventoryHUD");
        foreach(Transform slot in panel)
        {
            Image image = slot.GetComponent<Image>();
            Slot button = slot.GetComponent<Slot>();
            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.item.itemImage;
                button.item = e.item;

                break;
            }
        }
    }
}
