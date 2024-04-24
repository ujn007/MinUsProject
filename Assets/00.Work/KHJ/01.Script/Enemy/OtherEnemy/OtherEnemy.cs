using System;
using UnityEngine;

public enum OtherStateEnum
{
    Stay,
    Move
}

public class OtherEnemy : Enemy
{
    public EnemyStateMachine<OtherStateEnum> StateMachine { get; private set; }

    public override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine<OtherStateEnum>();

        foreach (OtherStateEnum stateEnum in Enum.GetValues(typeof(OtherStateEnum)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"Other{typeName}State");

            try
            {
                var enemyState = Activator.CreateInstance(t, this, StateMachine) as EnemyState<OtherStateEnum>;
                StateMachine.AddState(stateEnum, enemyState);
            }
            catch (Exception e)
            {
                Debug.LogError($"Enemy Skeleton : no state [ {typeName} ]");
                Debug.LogError(e);
            }
        }
    }

    protected void Start()
    {
        StateMachine.Initialize(OtherStateEnum.Stay, this);
    }

    protected void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }
}
