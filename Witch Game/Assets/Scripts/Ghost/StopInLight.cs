using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopInLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        Debug.Log("In light trigger");
        if(other.gameObject.tag == "Light"){
            Debug.Log("Entered the torchlight");
            if(other.gameObject.GetComponent<Light>().enabled){
                Debug.Log("Stop moving");
                ghost.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.0f;
            } else{
                Debug.Log("Move again");
                ghost.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 3.5f;
            }
        }
    }
}
