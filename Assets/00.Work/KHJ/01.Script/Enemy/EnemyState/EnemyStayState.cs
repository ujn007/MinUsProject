using System.Collections;
using UnityEngine;

public class EnemyStayState : EnemyState
{
    public EnemyStayState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (enemy.canMoveEvent)
        {
            stateMachine.ChangeState(EnemyStateEnum.Move);
            enemy.canMoveEvent = false;
        }
    }
}
