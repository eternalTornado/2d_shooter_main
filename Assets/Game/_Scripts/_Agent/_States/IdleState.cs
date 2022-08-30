using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Agent agent) : base(agent)
    {
        type = StateType.Idle;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
