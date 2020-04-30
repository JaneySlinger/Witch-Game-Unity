using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSetup : MonoBehaviour
{
    public PersistenceManager persistenceManager;
    public GameObject spellbook;
    public GameObject ingredientThree;
    // Start is called before the first frame update
    void Start()
    {
        ActivateSpellbook();
        ActivateIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateSpellbook(){
        if(!persistenceManager.fireSpellKnown){
            spellbook.SetActive(true);
        }
    }

    void ActivateIngredient(){
        if(!persistenceManager.ingredientThreeCollected){
            ingredientThree.SetActive(true);
        }
    }
}
