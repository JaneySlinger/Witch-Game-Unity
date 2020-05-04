using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potion : MonoBehaviour
{
    public GameObject potionColour;
    public Material bluePotion;
    public Material greenPotion;
    public Material redPotion;
    public Material purplePotion;
    public Transform ingredientTransform;
    public PersistenceManager persistenceManager;
    public HUDManager hUDManager;
    public float timeBeforeEndTransition = 3.0f;

    public void AddIngredient(GameObject ingredient){
        persistenceManager.ingredients_submitted += 1;
        SetColour();
        GameObject clone = Instantiate(ingredient,ingredientTransform.position,ingredientTransform.rotation);
        Destroy(clone, 2);
        Debug.Log("object is destroyed");
        if(persistenceManager.ingredients_submitted == 3){
            WinGame();
        }
        
    }

    public void SetColour(){
        if(persistenceManager.ingredients_submitted == 0){
            potionColour.GetComponent<Renderer>().material = bluePotion;
        } else if (persistenceManager.ingredients_submitted == 1)
        {
            potionColour.GetComponent<Renderer>().material = greenPotion;
        } else if (persistenceManager.ingredients_submitted == 2)
        {
            potionColour.GetComponent<Renderer>().material = redPotion;
        } else if (persistenceManager.ingredients_submitted == 3)
        {
            potionColour.GetComponent<Renderer>().material = purplePotion;
        } 
    }

    public void WinGame(){
        StartCoroutine("WaitForGameEnd");
    }
    

    private IEnumerator WaitForGameEnd(){
        yield return new WaitForSeconds(2.0f);
        hUDManager.SetNotificationText("You won!");
        yield return new WaitForSeconds(timeBeforeEndTransition);
        SceneManager.LoadScene(0);
        
    }

}
