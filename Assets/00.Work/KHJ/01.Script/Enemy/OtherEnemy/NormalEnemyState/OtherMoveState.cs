using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMoveState : EnemyState<OtherStateEnum>
{
    public OtherMoveState(Enemy _enemy, EnemyStateMachine<OtherStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("나는 다른에너미 움직임");
    }
}
