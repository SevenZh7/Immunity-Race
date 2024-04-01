using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : Basestate
{
    private Enemy enemy;
    private Transform playerTransform;

    public ChaseState(Enemy enemy)
    {
        this. enemy = enemy;
        playerTransform = enemy.player.transform;
    }


    public override void Enter()
    {
        enemy.Agent.SetDestination(playerTransform.position);
    }

    public override void Perform()
    {
        // Chase player logic
    }

    public override void Exit()
    {
        // Exit chase state logic
    }
}
