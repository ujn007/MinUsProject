using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class NormalMoveState : EnemyState<NormalStateEnum>
{
    public bool canMove;

    public Transform moveToTrm = null;
    public GameObject moveToObj = null;

    public NormalMoveState(Enemy _enemy, EnemyStateMachine<NormalStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        List<Transform> goRoads = enemy.targets;
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!canMove)
            {
                enemy.CheckRoad(ref moveToTrm, ref moveToObj);

                Debug.Log(moveToObj.layer);
                if (moveToObj.layer == 1 << 7) //7이 플레이어
                {
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
