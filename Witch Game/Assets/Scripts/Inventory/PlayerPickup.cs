using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Inventory inventory;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        IInventoryItem item = hit.gameObject.GetComponent<IInventoryItem>();

        if(item!=null)
        {
            Debug.Log("Colliding with the object");
            
            inventory.addItem(item);
        }
    }

}
