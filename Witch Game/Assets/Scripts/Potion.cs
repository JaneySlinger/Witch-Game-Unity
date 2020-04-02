using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject potionColour;
    public Material bluePotion;
    public Transform ingredientTransform;

    public void AddIngredient(GameObject ingredient){
        Debug.Log("changing colour");

        potionColour.GetComponent<Renderer>().material = bluePotion;
        GameObject clone = Instantiate(ingredient,ingredientTransform.position,ingredientTransform.rotation);
        Destroy(clone, 2);
        Debug.Log("object is destroyed");
    }

}
