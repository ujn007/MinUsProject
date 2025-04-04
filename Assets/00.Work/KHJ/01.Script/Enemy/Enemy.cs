using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
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
    [HideInInspector] public Transform ownerTrm;

    private PlayerEnergy[] playerEnergys;

    public EnemyStateMachine StateMachine { get; private set; }
    public bool canMoveEvent;


    public void Awake()
    {
        ownerTrm = transform;

        StateMachine = new EnemyStateMachine();

        StateMachine.AddState(EnemyStateEnum.Stay, new EnemyStayState(this, StateMachine));
        StateMachine.AddState(EnemyStateEnum.Move, new EnemyMoveState(this, StateMachine));
        StateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this, StateMachine));
    }

    private void Start()
    {
        Initialize();   
        StateMachine.Initialize(EnemyStateEnum.Stay, this);

        enemMng.playerPieces[0].playerEnergy.PlayerTurnEnd += HandleEnemyTurnEvent;
        enemMng.playerPieces[1].playerEnergy.PlayerTurnEnd += HandleEnemyTurnEvent;
        enemMng.playerPieces[2].playerEnergy.PlayerTurnEnd += HandleEnemyTurnEvent;
    }

    private void HandleEnemyTurnEvent()
    {
        canMoveEvent = true;
    }

    private void OnDestroy()
    {
        enemMng.playerPieces[0].playerEnergy.PlayerTurnEnd -= HandleEnemyTurnEvent;
        enemMng.playerPieces[1].playerEnergy.PlayerTurnEnd -= HandleEnemyTurnEvent;
        enemMng.playerPieces[2].playerEnergy.PlayerTurnEnd -= HandleEnemyTurnEvent;
        enemMng.enemyList.Remove(this);
    }

    public override void Update()
    {
        base.Update();
        StateMachine.CurrentState.UpdateState();
    }

    public Coroutine StartDelayCallback(float time, Action Callback)
    {
        return StartCoroutine(DelayCoroutine(time, Callback));
    }

    private IEnumerator DelayCoroutine(float time, Action Callback)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
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

        foreach (PlayerPieces player in enemMng.playerPieces)
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
