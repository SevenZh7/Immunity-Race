using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public Basestate activeState;

    public void Initialise(Enemy enemy)
    {
        PatrolState patrolState = new PatrolState(enemy); // Pass the Enemy reference to the PatrolState constructor
        ChangeState(patrolState);
    }

    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(Basestate newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState; // Assign the new state to activeState

        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>(); // Set the enemy property of the active state
            activeState.Enter();
        }
    }
}