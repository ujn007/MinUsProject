using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public bool canMove;
    private bool dd;

    #region ref
    public Transform moveToTrm = null;
    public GameObject moveToObj = null;
    #endregion

    public EnemyMoveState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void UpdateState()
    {
        if (enemy.canMoveEvent && !canMove)
        {
            if (enemy.SetMinEenemy(enemy))
            {
                enemy.CheckRoad(ref moveToTrm, ref moveToObj);

                Debug.Log(moveToObj.name);
                if (moveToObj.layer == 7) //7이 플레이어
                {
                    stateMachine.ChangeState(EnemyStateEnum.Attack);
                }
                else
                {
                    enemy.transform.DOMove(moveToTrm.position + Vector3.forward, 0.5f).OnComplete(() => canMove = false);
                    TMananger.instance.StartPlayerTurn();
                }
            }
        }
    }
}
