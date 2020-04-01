using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject potionColour;
    public Material bluePotion;
    public void AddIngredient(){
        Debug.Log("changing colour");

        potionColour.GetComponent<Renderer>().material = bluePotion;
    }

}
