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

        agent.agentRenderer.PlayAnimation(AnimType.Idle);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnMovement(Vector2 movementVector)
    {
        if (movementVector.magnitude > 0)
            agent.TransitionToState(StateType.Move);
    }
}
