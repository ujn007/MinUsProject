using DG.Tweening;
using System;
using System.Collections;
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

        Attack();
    }

    private void Attack()
    {
        Vector2 startPos = enemy.transform.position;

        Sequence sq = DOTween.Sequence();
        sq.Append(enemy.MoveTween((Vector2)moveState.moveToTrm.position, 0.1f));
        sq.AppendCallback(() =>
        {
            if (moveState.moveToObj.TryGetComponent(out PlayerPieces player))
            {
                player.HitPiece(1);

                if (player.GetHP() <= 0)
                {
                    EndAttack();
                    return;
                }

                enemy.StartCoroutine(HitEffectCoroutine(player));

                enemy.MoveTween(startPos, 0.5f, Ease.OutQuart).OnComplete(() =>
                {
                    EndAttack();
                });
            }
        });
    }

    private IEnumerator HitEffectCoroutine(PlayerPieces player)
    {
        Material mat= player.GetComponent<SpriteRenderer>().material;
        mat.SetColor("_EmissionColor", Color.white);
         
        yield return new WaitForSeconds(0.1f);

        mat.SetColor("_EmissionColor", Color.black);
    }

    private void EndAttack()
    {
        moveState.canMove = false;
        TMananger.instance.StartPlayerTurn();
        EnemyManager.Instance.enemyList.ForEach(enemy => enemy.StateMachine.ChangeState(EnemyStateEnum.Stay));
    }
}
