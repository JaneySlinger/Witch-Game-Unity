using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Attack: IState
{
    GhostController owner;
    NavMeshAgent agent;
    public float targetDistanceFromPlayer = 2.0f;
    //public float fireRate = 1.0f;
    //private float nextFire = 0.0f;

    public State_Attack(GhostController owner) {this.owner = owner;}

    public void Enter()
    {
        //if they are entering the attack state, find the last seen location and start moving if stopped
        //Debug.Log("entering attack state");
        agent = owner.GetComponent<NavMeshAgent>();
        if(owner.seenTarget)
        {
            agent.destination = owner.lastSeenPosition;
            agent.isStopped = false;
        }
    }

    public void Execute()
    {
        //find path to player and move there
        //Debug.Log("updating attack state");

        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;

        if(!agent.pathPending && agent.remainingDistance < targetDistanceFromPlayer)
        {
            agent.isStopped = true;
        }

        if(owner.seenTarget != true)
        {
            //Debug.Log("lost sight");
            //change state to search for the player
            owner.stateMachine.ChangeState(new State_Searching(owner));
        }
        
    }

    public void Exit()
    {
        //Debug.Log("exiting attack state");
        agent.isStopped = true;
    }
}
