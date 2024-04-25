using System.Collections.Generic;
using UnityEngine;

public class EnemyStayState : EnemyState
{
    public EnemyStayState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.ChangeState(EnemyStateEnum.Move);
    }
}
