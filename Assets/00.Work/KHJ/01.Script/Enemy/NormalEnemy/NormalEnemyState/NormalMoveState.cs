using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class NormalMoveState : EnemyState<NormalStateEnum>
{
    bool canMove;
    public NormalMoveState(Enemy _enemy, EnemyStateMachine<NormalStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        List<Transform> goRoads = enemy.targets;




    }

    public override void Exit()
    {
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!canMove)
            {
                Transform moveToTrm = null;
                LayerMask moveToLayer = 1 << 0;
                enemy.CheckRoad(ref moveToTrm, ref moveToLayer);

                if ((int)moveToLayer == 7) //7이 플레이어
                {
                    enemy.transform.DOMove(moveToTrm.position, 0.5f).OnComplete(() => canMove = false);
                    stateMachine.ChangeState(NormalStateEnum.Attack);
                }
                else
                {
                    enemy.transform.DOMove(moveToTrm.position, 0.5f).OnComplete(() => canMove = false);
                }
                canMove = true;
            }
        }
    }
}
