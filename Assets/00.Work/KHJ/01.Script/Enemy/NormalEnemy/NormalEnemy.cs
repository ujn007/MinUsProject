using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum NormalStateEnum
{
    Stay,
    Move,
    Attack
}

public class NormalEnemy : Enemy
{
    public EnemyStateMachine<NormalStateEnum> StateMachine { get; private set; }
    public Transform ownerTrm;

    public override void Awake()
    {
        base.Awake();
        ownerTrm = transform;

        StateMachine = new EnemyStateMachine<NormalStateEnum>();

        StateMachine.AddState(NormalStateEnum.Stay, new NormalStayState(this, StateMachine));
        StateMachine.AddState(NormalStateEnum.Move, new NormalMoveState(this, StateMachine));
        StateMachine.AddState(NormalStateEnum.Attack, new NormalAttackState(this, StateMachine));
    }

    protected void Start()
    {
        StateMachine.Initialize(NormalStateEnum.Stay, this);
    }

    protected void Update()
    {
        

        StateMachine.CurrentState.UpdateState();
    }
}
