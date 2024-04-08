using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : Basestate
{
    private float moveTimer;
    private float losePlayerTimer;
    
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new ChaseState(enemy)); // Pass 'enemy' instance to ChaseState constructor
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 4)
            {
                stateMachine.ChangeState(new PatrolState(enemy));
            }
        }
    }
}