using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOnContact : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject player;

    public float x,y,z;
    public float rotX, rotY, rotZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Colliding with " + other.gameObject);
        if(other.gameObject == target){
            //move the player back to the start of the area - needs implementing
            Debug.Log("Colliding with player");
            Debug.Log("Destroy the player");
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(x,y,z);
            player.transform.rotation = new Quaternion(rotX, rotY, rotZ, 0.0f);
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
