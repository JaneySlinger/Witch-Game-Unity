using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSetUp : MonoBehaviour
{
    public PersistenceManager persistenceManager;
    public GameObject rock1;

    public List<GameObject> levitateItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SetUpPickupObjects();
        SetUpInventoryObjects();
        levitateItems.Add(rock1);
        persistenceManager.SetObjectPositions(levitateItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpPickupObjects(){
        //position of rocks and sticks

    }

    void SetUpInventoryObjects(){
        //whether the potion ingredients and spell books should be visible
    }
}
