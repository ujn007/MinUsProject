using DG.Tweening;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private EnemyMoveState moveState;

    public EnemyAttackState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        moveState = stateMachine.GetState(EnemyStateEnum.Move) as EnemyMoveState;
        Debug.Log(moveState);

        Attack();
    }

    private void Attack()
    {
        Vector2 startPos = enemy.transform.position;

        Sequence sq = DOTween.Sequence();
        sq.Append(enemy.MoveTween((Vector2)moveState.moveToTrm.position, 0.1f)).OnComplete(() =>
        {
            if (moveState.moveToObj.TryGetComponent(out PlayerPieces player))
            {
                
            }
        });

        sq.Append(enemy.MoveTween(startPos, 0.5f, Ease.OutQuart)).OnComplete(() =>
        {
            moveState.canMove = false;  
            stateMachine.ChangeState(EnemyStateEnum.Move);
        });
    }
}
