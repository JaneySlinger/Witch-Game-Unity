using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Patrol: IState
{
    GhostController owner;
    NavMeshAgent agent;
    Waypoint waypoint;

    public State_Patrol(GhostController owner) {this.owner = owner;}

    public void Enter()
    {
        //when we enter the patrol state, we want to find the next waypoint and start moving towards it
        //Debug.Log("entering patrol state");
        waypoint = owner.waypoint;
        agent = owner.GetComponent<NavMeshAgent>();
        agent.destination = waypoint.transform.position;
        //start moving, in case we were previously stopped
        agent.isStopped = false;
    }

    public void Execute()
    {
        //Debug.Log("updating patrol state");
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Waypoint nextWaypoint = waypoint.nextWaypoint;
            waypoint = nextWaypoint;
            agent.destination = waypoint.transform.position;
        }

        //if, during the patrolling state, the enemy sees the player, then the state machine should transition into the attack state
        if(owner.seenTarget)
        {
            owner.stateMachine.ChangeState(new State_Attack(owner));
        }
    }

    public void Exit()
    {
        //Debug.Log("exiting patrol state");
        //stop moving
        agent.isStopped = true;
    }
}
