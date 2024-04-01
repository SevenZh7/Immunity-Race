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
    public float fieldofView = 85f;
    public float eyeHeight;
    public string currentState;
    private bool isChasing = false;


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

    private void Update()
    {
        if (CanSeePlayer())
        {
            StartChasing();
        }
        else
        {
            StopChasing();
        }

        if (isChasing)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    public bool CanSeePlayer()
    {
     if (player != null)
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Check if the player is within the field of view angle
        if (angleToPlayer < fieldofView / 2f)
        {
            RaycastHit hit;
            // Check if there's no obstacle between the enemy and the player
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, sightDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true; // Player is within sight and field of view
                }
            }
        }
    }

        return false;
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
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
