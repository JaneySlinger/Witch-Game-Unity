using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
    public LayerMask layerMask;
    GameObject heldObject;
    public Transform holdPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        if (Input.GetButtonDown("Fire1")){
            //pick the object up
            if(heldObject == null){
                RaycastHit colliderHit;
                if (Physics.Raycast(transform.position, transform.forward,out colliderHit, 10.0f, layerMask)){
                    heldObject = colliderHit.collider.gameObject;
                    heldObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        if (Input.GetButtonUp("Fire1")){
            //drop the object again
            if (heldObject!=null){
                heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().ResetInertiaTensor();
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject = null;
            }
        }

        if(Input.GetButtonDown("Fire2")){
            //if right button is clicked and the user is holding an object, fire the object forwards
            if(heldObject != null){
                heldObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10.0f, ForceMode.Impulse);
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject = null;
            }
        }

        if (heldObject != null){
            //move the thing we are holding
            heldObject.GetComponent<Rigidbody>().MovePosition(holdPosition.position);
            heldObject.GetComponent<Rigidbody>().MoveRotation(holdPosition.rotation);
        }
    }
}
