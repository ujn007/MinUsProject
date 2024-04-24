using System;
using UnityEngine;

public class EnemyState<T> where T : Enum
{
    protected EnemyStateMachine<T> stateMachine;
    protected Enemy enemy;
    protected Rigidbody2D rigidbody; //�̰� ���ǻ� �����°�

    public EnemyState(Enemy _enemy, EnemyStateMachine<T> _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }

    //���¿� �������� �� ������ �Լ�
    public virtual void Enter()
    {

    }

    //���¸� ������ ������ �Լ�
    public virtual void Exit()
    {

    }

    public virtual void UpdateState()
    {

    }
}
