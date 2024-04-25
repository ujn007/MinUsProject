using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public bool canMove;

    public Transform moveToTrm = null;
    public GameObject moveToObj = null;

    public EnemyMoveState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
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
                if (moveToObj.layer == 7) //8이 플레이어
                {
                    stateMachine.ChangeState(EnemyStateEnum.Attack);
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
