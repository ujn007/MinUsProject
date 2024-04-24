using System.Collections.Generic;
using UnityEngine;

public class NormalStayState : EnemyState<NormalStateEnum>
{
    public NormalStayState(Enemy _enemy, EnemyStateMachine<NormalStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.ChangeState(NormalStateEnum.Move);
    }
}
