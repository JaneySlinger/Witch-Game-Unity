using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked(){
        Debug.Log("removing the button from view");
        gameObject.SetActive(false);
    }
}
