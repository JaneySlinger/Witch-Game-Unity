using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardItemUsed : MonoBehaviour
{
    public string Key;  //the key that selects that slot (usually numbers 1-3)
    public Slot slotScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(Key)){
            //if the key has been pressed, use the item;
            Debug.Log("Using item " + Key + " from the key press");
            slotScript.OnItemClicked();
        }
    }
}
