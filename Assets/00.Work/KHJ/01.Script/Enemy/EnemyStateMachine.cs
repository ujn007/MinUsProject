using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum EnemyStateEnum
{
    Stay,
    Move,
    Attack
}

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }
    public Dictionary<EnemyStateEnum, EnemyState> StateDictionary;

    public Enemy enemyBase;

    public EnemyStateMachine()
    {
        StateDictionary = new Dictionary<EnemyStateEnum, EnemyState>();
    }

    public void Initialize(EnemyStateEnum startState, Enemy enemy)
    {
        CurrentState = StateDictionary[startState];
        CurrentState.Enter();
        enemyBase = enemy;
    }

    public void ChangeState(EnemyStateEnum newState, bool forceMode = false)
    {
        CurrentState.Exit();
        CurrentState = StateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(EnemyStateEnum stateEnum, EnemyState enemyState)
    {
        StateDictionary.Add(stateEnum, enemyState);
    }

    public EnemyState GetState(EnemyStateEnum stateEnum)
    {
        return StateDictionary[stateEnum];
    }
}
