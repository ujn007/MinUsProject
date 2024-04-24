using System;
using UnityEngine;

public class EnemyState<T> where T : Enum
{
    protected EnemyStateMachine<T> stateMachine;
    protected Enemy enemy;
    protected Rigidbody2D rigidbody; //이건 편의상 가져온거

    public EnemyState(Enemy _enemy, EnemyStateMachine<T> _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }

    //상태에 진입했을 때 실행할 함수
    public virtual void Enter()
    {

    }

    //상태를 나갈때 실행할 함수
    public virtual void Exit()
    {

    }

    public virtual void UpdateState()
    {

    }
}
