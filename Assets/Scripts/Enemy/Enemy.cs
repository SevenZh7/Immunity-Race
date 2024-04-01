using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject player;

    public float chaseSpeed = 5f;
    public float attackDamage = 10f;

    public Path path; // Assuming you have a Path variable
    public int EnemyHP = 100;
    public NavMeshAgent Agent { get => agent; }
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public string currentState;
    private bool isChasing = false;
     public float eyeHeight;


    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (stateMachine != null)
        {
            stateMachine.Initialise(this); // Pass a reference to this Enemy object to the StateMachine
        }
    }

        void Update()
    {
        CanSeePlayer();
        // Update state machine
        if (stateMachine != null)
        {
            stateMachine.Update();
        }
    }

    public void ChangeState(Basestate newState)
    {
        if (stateMachine != null)
        {
            stateMachine.ChangeState(newState);
        }
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleToPlayer >= -fieldOfView / 2f && angleToPlayer <= fieldOfView / 2f)
            {
                Ray ray = new Ray(transform.position + Vector3.up * eyeHeight, directionToPlayer);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, sightDistance))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        ChangeState(new ChaseState(this));
                        return true;
                    }
                }
            }
        }
        ChangeState(new PatrolState(this));
        return false;
    }


        public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer();
        }
    }
         void AttackPlayer()
    {
         PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Convert float to int before passing to TakeDamage
            int damage = Mathf.RoundToInt(attackDamage);
            playerHealth.TakeDamage(damage);
        }
    }

    public void StartChasing()
    {
        isChasing = true;
        agent.speed = chaseSpeed;
    }

    public void StopChasing()
    {
        isChasing = false;
        agent.ResetPath();
    }
    
}
