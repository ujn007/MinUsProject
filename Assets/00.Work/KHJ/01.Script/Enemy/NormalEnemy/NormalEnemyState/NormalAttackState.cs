using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackState : EnemyState<NormalStateEnum>
{
    public NormalAttackState(Enemy _enemy, EnemyStateMachine<NormalStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }
}
