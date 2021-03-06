﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public bool isActive;
    public bool inRange;
    public HUDManager hudManager; 
    public int destinationArea;
    public PersistenceManager persistenceManager;
    public Inventory inventory;
    private GameObject[] rocks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") && inRange){
            LoadArea(destinationArea);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            inRange = true;
            hudManager.SetToolTipText("Press enter to travel");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            inRange = false;
            hudManager.SetToolTipText("Press enter to travel");
            hudManager.ClearToolTip();
        }
    }

    private void LoadArea(int areaIndex){
        if(areaIndex == 2){
            rocks = GameObject.FindGameObjectsWithTag("holdable");
            if(rocks.Length != 0){ 
                persistenceManager.SetObjectPositions(rocks);
            }
        }
        for (int i = 0; i < inventory.items.Count; i++)
        {
            Debug.Log(inventory.items[i].itemName);
        }
        
        persistenceManager.SetInventory(inventory.items);
        SceneManager.LoadScene(areaIndex);
    }

    
}
