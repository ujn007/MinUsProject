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

    public override void Enter()
    {
        base.Enter();
        enemy.StartDelayCallback(0.5f, () => Movement());
    }

    private void Movement()
    {
        if (!canMove)
        {
            if (enemy.SetMinEenemy(enemy))
            {
                canMove = true;
                enemy.CheckRoad(ref moveToTrm, ref moveToObj);

                if (moveToObj.layer == 7) //7이 플레이어
                {
                    stateMachine.ChangeState(EnemyStateEnum.Attack);
                }
                else
                {
                    enemy.transform.DOMove(moveToTrm.position + Vector3.forward, 0.5f)
                        .OnComplete(() =>
                        {
                            TMananger.instance.StartPlayerTurn();
                            EnemyManager.Instance.enemyList.ForEach(enemy => enemy.StateMachine.ChangeState(EnemyStateEnum.Stay));
                            canMove = false;
                        });
                }
            }
        }
    }
}
