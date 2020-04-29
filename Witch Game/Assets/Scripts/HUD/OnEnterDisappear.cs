using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit")){
            Debug.Log("removing the button from view");
            gameObject.SetActive(false);
        }
    }
}
