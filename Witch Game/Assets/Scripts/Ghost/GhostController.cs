using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    // Start is called before the first frame update

    UnityEngine.AI.NavMeshAgent agent;
    SphereCollider sightCollider;
    public Waypoint waypoint;

    public float sightFov = 110.0f;
    public bool seenTarget = false;
    public GameObject target;
    public Vector3 lastSeenPosition;

    public StateMachine stateMachine = new StateMachine();

    //public GameObject shot;
    //public Transform shotTransform;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoint.transform.position;
        sightCollider = GetComponent<SphereCollider>();
        stateMachine.ChangeState(new State_Patrol(this));

    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    // public void Fire()
    // {
    //     var direction = lastSeenPosition - shotTransform.position;
    //     Instantiate(shot, shotTransform.position, Quaternion.LookRotation(direction));

    // }

    private void OnTriggerStay(Collider other){
        //is it the player
        if(other.gameObject == target){
            //angle between us and the player
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            //reset whether we've seen the player
            seenTarget = false;

            RaycastHit hit;

            // is it less than our field of view
            if (angle < sightFov * 0.5f){
                //if the raycast hits the player we know
                //there is nothing in the way
                //adding transform.up raises from the floor by 1 unit
                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, sightCollider.radius)){
                    if (hit.collider.gameObject == target){
                        //flag that we've seen the player
                        //remember their position
                        seenTarget = true;
                        lastSeenPosition = target.transform.position;
                    }
                }
            }
        }
    }


    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        if(sightCollider != null){
            Gizmos.DrawWireSphere(transform.position, sightCollider.radius);
            if(seenTarget) Gizmos.DrawLine(transform.position, lastSeenPosition);
            if(lastSeenPosition != Vector3.zero){
                //draw a small sphere
                Gizmos.DrawSphere(lastSeenPosition, 0.2f);
            }

            Vector3 rightPeripheral;
            rightPeripheral = (Quaternion.AngleAxis(sightFov * 0.5f, Vector3.up) * transform.forward * sightCollider.radius);

            Vector3 leftPeripheral;
            leftPeripheral = (Quaternion.AngleAxis(sightFov * 0.5f, Vector3.up) * transform.forward * sightCollider.radius * -1.0f);


            //draw lines for the left and right edges of the field of view
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, rightPeripheral);
            Gizmos.DrawLine(transform.position, leftPeripheral);

        }
    }
}
