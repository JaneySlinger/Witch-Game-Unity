using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTorchOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Light light;
    public float seconds = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("something collided");
        if(other.tag == "bullet"){
            //Debug.Log("bullet collided");
            StartCoroutine(LightOnCR());
        }
    }

    private IEnumerator LightOnCR(){
        light.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(seconds);
        light.GetComponent<Light>().enabled = false;
    }
}
