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
        sq.Append(enemy.MoveTween((Vector2)moveState.moveToTrm.position, 0.1f)).OnComplete(() =>
        {
            if (moveState.moveToObj.TryGetComponent(out PlayerPieces player))
            {
                Debug.Log($"플레이어 찾아옴 : {player.name}");
                player.HitPiece(1);
                enemy.StartCoroutine(HitEffectCoroutine(player));
            }
        });

        sq.Append(enemy.MoveTween(startPos, 0.5f, Ease.OutQuart)).OnComplete(() =>
        {
            moveState.canMove = false;
            TMananger.instance.StartPlayerTurn();
            EnemyManager.Instance.enemyList.ForEach(enemy => enemy.StateMachine.ChangeState(EnemyStateEnum.Stay));
        });
    }

    private IEnumerator HitEffectCoroutine(PlayerPieces player)
    {
        Material mat= player.GetComponent<SpriteRenderer>().material;
        mat.SetColor("_EmissionColor", Color.white);
         
        yield return new WaitForSeconds(0.1f);

        mat.SetColor("EmissionColor", Color.black);
    }
}
