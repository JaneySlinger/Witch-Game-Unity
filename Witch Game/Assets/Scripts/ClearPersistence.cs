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
        persistenceManager.ResetObjectPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
