using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public HUDManager hudManager;
    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("e") && inRange){
            hudManager.SetNotificationText("It's time for your test to become a full-blown witch. I need you to find the 3 ingredients to make a potion.");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            //set in range to true and display that you can press 'e' to talk to them
            inRange = true;
            hudManager.SetToolTipText("Press 'e' to talk");
        }
        

    }

    private void OnTriggerExit(Collider other) {
        inRange = false;
        hudManager.ClearToolTip();
    }



    
}
