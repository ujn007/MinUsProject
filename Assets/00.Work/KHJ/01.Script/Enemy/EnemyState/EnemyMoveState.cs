using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public bool canMove;

    #region ref
    public Transform moveToTrm = null;
    public GameObject moveToObj = null;
    #endregion

    public EnemyMoveState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!canMove && enemy.so.name == enemy.CheckMinEnemy())
            {
                enemy.CheckRoad(ref moveToTrm, ref moveToObj);
                moveToTrm.position += Vector3.forward;

                Debug.Log(moveToObj.layer);
                if (moveToObj.layer == 7) //7이 플레이어
                {
                    stateMachine.ChangeState(EnemyStateEnum.Attack);
                }
                else
                {
                    enemy.transform.DOMove(moveToTrm.position + Vector3.forward, 0.5f).OnComplete(() => canMove = false);
                }
            }
        }
    }
}
