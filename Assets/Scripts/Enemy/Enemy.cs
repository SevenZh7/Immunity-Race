using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public Path path; // Assuming you have a Path variable

    public NavMeshAgent Agent { get => agent; }

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        
        if (stateMachine != null)
        {
            stateMachine.Initialise(this); // Pass a reference to this Enemy object to the StateMachine
        }
    }
}