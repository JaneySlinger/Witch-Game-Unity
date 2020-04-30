using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSetUp : MonoBehaviour
{
    public PersistenceManager persistenceManager;
    private GameObject rock;
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpPickupObjects();
        SetUpInventoryObjects();    
    }

    void SetUpPickupObjects(){
        //position of rocks and sticks
        for (int i = 0; i < persistenceManager.prefabs.Count; i++)
        {
            SpawnRock(persistenceManager.prefabs[i],persistenceManager.positions[i], persistenceManager.scales[i] ,persistenceManager.xAngles[i],persistenceManager.yAngles[i],persistenceManager.zAngles[i]);
        }
    }

    void SetUpInventoryObjects(){
        //whether the potion ingredients and spell books should be visible
    }

    void SpawnRock(GameObject prefab, Vector3 position, Vector3 scale, float xAngle, float yAngle, float zAngle){
        rock = Instantiate(prefab, position, Quaternion.identity);
        rock.transform.localScale = scale;
        rock.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        
    }
}
