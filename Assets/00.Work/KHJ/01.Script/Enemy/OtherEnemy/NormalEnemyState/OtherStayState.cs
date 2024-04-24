using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherStayState : EnemyState<OtherStateEnum>
{
    public OtherStayState(Enemy _enemy, EnemyStateMachine<OtherStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("���� �ٸ����ʹ�");
        stateMachine.ChangeState(OtherStateEnum.Move);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
