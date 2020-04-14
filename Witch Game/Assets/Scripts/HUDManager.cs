using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Inventory inventory;
    public Transform notification;
    
    // Start is called before the first frame update
    void Start()
    {
        //when started register with the event handler of the inventory
        inventory.ItemAdded += InventoryItemAdded;

        //register to the item removed event so that the item can be removed from the inventory
        inventory.ItemUsed += InventoryItemUsed;
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

    private void InventoryItemUsed(object sender, InventoryEventArgs e)
    {
        Transform panel = transform.Find("InventoryHUD");
        Debug.Log("HUDManager: Removing the picture from the slot.");

        //find the slot with the removed item and disable the image
        foreach(Transform slot in panel){
            Image image = slot.GetComponent<Image>();
            Slot button = slot.GetComponent<Slot>();
            if(image.sprite == e.item.itemImage){
                //clear the slot in the panel
                image.enabled = false;
                image.sprite = null;
                button.item = null;
                break;
            }
        }

        if(e.item.tag == "book"){
            string spellName = e.item.itemName;
            string spellDescription = e.item.description;
            string panelText = "You leant the spell: " + spellName + "\n. " + spellDescription;
            SetPanelText(panelText);
            
        } 
 
    }

    public void SetPanelText(string text){
        notification.gameObject.SetActive(true);
        notification.GetComponentInChildren<Text>().text = text;
    }


    
}
