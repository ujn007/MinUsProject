using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine<T> where T : Enum
{
    public EnemyState<T> CurrentState { get; private set; }
    public Dictionary<T, EnemyState<T>> StateDictionary = new Dictionary<T, EnemyState<T>>();

    public Enemy enemyBase;

    public void Initialize(T startState, Enemy enemy)
    {
        CurrentState = StateDictionary[startState];
        CurrentState.Enter();
        enemyBase = enemy;
    }

    public void ChangeState(T newState, bool forceMode = false)
    {
        CurrentState.Exit();
        CurrentState = StateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(T stateEnum, EnemyState<T> enemyState)
    {
        StateDictionary.Add(stateEnum, enemyState);
    }

    public EnemyState<T> GetState(T stateEnum)
    {
        return StateDictionary[stateEnum];
    }
}
