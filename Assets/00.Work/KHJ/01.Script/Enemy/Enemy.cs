using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : EnemyGroup
{
    [Header("SO")]
    public EnemyTpyeSO so;

    [Header("Setting Enemy")]
    public int damage;
    public float checkMoveDir = 1.3f;
    public float checkRadius;

    [Header("LayerMask")]
    public LayerMask whatIsPlayer;

    [HideInInspector] public List<EnemyTpyeSO> enemySOList = new List<EnemyTpyeSO>();

    public EnemyStateMachine StateMachine { get; private set; }
    public Transform ownerTrm;

    private float min = Mathf.Infinity;

    public void Awake()
    {
        ownerTrm = transform;

        StateMachine = new EnemyStateMachine();

        StateMachine.AddState(EnemyStateEnum.Stay, new EnemyStayState(this, StateMachine));
        StateMachine.AddState(EnemyStateEnum.Move, new EnemyMoveState(this, StateMachine));
        StateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this, StateMachine));
    }

    public override void Start()
    {
        base.Start();
        StateMachine.Initialize(EnemyStateEnum.Stay, this);
        print(CheckMinEnemy());
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    public void CheckRoad(ref Transform trm, ref GameObject obj)
    {
        Vector2[] dirs = so.moveDir;

        Transform closestRoad = null;
        Collider2D roadCol = null;

        Transform minPlayer = MinPlayerDis();
        float minDistance = float.MaxValue;

        foreach (Vector2 dir in dirs)
        {
            roadCol = Physics2D.OverlapCircle(transform.position + (Vector3)dir * checkMoveDir, checkRadius);

            if (roadCol == null || roadCol.gameObject.layer == 8) continue;

            float distance = Vector3.Distance(roadCol.transform.position, minPlayer.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestRoad = roadCol.transform;
            }
        }

        trm = closestRoad;
        obj = closestRoad.gameObject;
    }

    private Transform MinPlayerDis()
    {
        Transform closestPlayer = null;
        float minDistance = float.MaxValue; // 최소 거리를 최대값으로 초기화

        foreach (PlayerPieces player in playerPieces)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPlayer = player.transform;
            }
        }

        return closestPlayer;
    }

    public Tween MoveTween(Vector3 movePos, float time, Ease ease = Ease.Linear)
    {
        return transform.DOMove(movePos, time).SetEase(ease);
    }
}
