using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPersistence : MonoBehaviour
{
    public PersistenceManager persistenceManager;
    // Start is called before the first frame update
    void Start()
    {
        persistenceManager.SetLevitateSpell(false);
        persistenceManager.SetFireSpell(false);
        persistenceManager.SetFireCollected(false);
        persistenceManager.SetLevitateCollected(false);
        persistenceManager.ResetObjectPositions();
        persistenceManager.ResetIngredientCollection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
