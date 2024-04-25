using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class NormalAttackState : EnemyState<NormalStateEnum>
{
    private EnemyState<NormalStateEnum> moveState;

    public NormalAttackState(Enemy _enemy, EnemyStateMachine<NormalStateEnum> _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        moveState = stateMachine.GetState(NormalStateEnum.Move);
        
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
