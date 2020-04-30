using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PersistenceManagerData", menuName = "ScriptableObjects/PersistenceManager", order = 1)]

public class PersistenceManager : ScriptableObject
{
    public bool fireSpellKnown;
    public bool levitateSpellKnown; 
    public int ingredients_submitted; //not done yet
    public List<IInventoryItem> storedItems = new List<IInventoryItem>();

    public List<Vector3> positions = new List<Vector3>();
    public List<Vector3> scales = new List<Vector3>();
    public List<float> xAngles = new List<float>(); 
    public List<float> yAngles = new List<float>(); 
    public List<float> zAngles = new List<float>(); 
    public List<GameObject> prefabs = new List<GameObject>();

    public List<Vector3> startPositions = new List<Vector3>();
    public List<Vector3> startScales = new List<Vector3>();
    public List<float> startXAngles = new List<float>(); 
    public List<float> startYAngles = new List<float>(); 
    public List<float> startZAngles = new List<float>(); 
    public List<GameObject> startPrefabs = new List<GameObject>();

    public void SetFireSpell(bool value){
        fireSpellKnown = value;
    }

    public void SetLevitateSpell(bool value){
        levitateSpellKnown = value;
    }

    public void SetInventory(List<IInventoryItem> items){
        Debug.Log("copying the list");
        storedItems = items;         
    }

    public void SetObjectPositions(GameObject[] objects){
        for (int i = 0; i < objects.Length; i++)
        {
            positions[i] = objects[i].transform.position;
            scales[i] = objects[i].transform.localScale;
            xAngles[i] = objects[i].transform.rotation.eulerAngles.x;
            yAngles[i] = objects[i].transform.rotation.eulerAngles.y;
            zAngles[i] = objects[i].transform.rotation.eulerAngles.z;
        }
    }

    public void ResetObjectPositions(){
        positions = new List<Vector3>(startPositions);
        scales = new List<Vector3>(startScales);
        xAngles = new List<float>(startXAngles);
        yAngles = new List<float>(startYAngles);
        zAngles = new List<float>(startZAngles);
        prefabs = new List<GameObject>(startPrefabs);
    }
}
