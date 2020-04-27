using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Searching: IState
{
    //transitions into from attacking if loses the player
    //move to the last seen position of the player
    // if it still can't see the player, transition to the patrol state
    //if it does regain sight of the player, transition back to attacking
    GhostController owner;
    NavMeshAgent agent;

    public State_Searching(GhostController owner) {this.owner = owner;}

    public void Enter()
    {
        //Debug.Log("entering the searching state");
        agent = owner.GetComponent<NavMeshAgent>();

        //move to last seen position of the player
        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;

    }

    public void Execute()
    {
        //Debug.Log("updating the searching state");
        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.isStopped = true;
            //if they still can't see the player, transition to the patrol state
            if(owner.seenTarget != true)
            {
                //Debug.Log("Still can't see the player, start patrolling");
                //change state to patrol
                owner.stateMachine.ChangeState(new State_Patrol(owner));
            } else {
                //Debug.Log("Found the player, attack");
                //change to attack state
                owner.stateMachine.ChangeState(new State_Attack(owner));
            }
        }



    }

    public void Exit()
    {
        //Debug.Log("exiting searching state");
        agent.isStopped = true;

    }
}
