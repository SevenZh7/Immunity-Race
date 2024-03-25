using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : Basestate
{
    private Enemy enemy; // Reference to the enemy

    public int waypointIndex;

    public PatrolState(Enemy enemy) // Constructor to pass the enemy reference
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        // Initialization code for entering the patrol state
        waypointIndex = 0; // Set initial waypoint index
        PatrolCycle(); // Start patrolling
    }

    public override void Perform()
    {
        PatrolCycle(); // Continuously patrol
    }

    public override void Exit()
    {
        // Cleanup code for exiting the patrol state
    }

    private void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            if (waypointIndex < enemy.path.waypoints.Count - 1)
                waypointIndex++;
            else
                waypointIndex = 0;

            // Set the destination to the next waypoint
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
        }
    }
}
