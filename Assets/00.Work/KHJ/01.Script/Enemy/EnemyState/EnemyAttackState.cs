using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private EnemyState moveState;

    public EnemyAttackState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        moveState = stateMachine.GetState(EnemyStateEnum.Move);
        Debug.Log(moveState);
        
        Attack();
    }

    private void Attack()
    {
        Vector3 startPos = enemy.transform.position;
        //enemy.MoveTween(moveToTrm.position, 0.1f).OnComplete(() =>
        //{
        //    enemy.MoveTween(startPos, 0.5f, Ease.OutQuart);
        //});
    }
}
