using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    private float currentVelocity;

    public MoveState(Agent agent) : base(agent)
    {
        type = StateType.Move;
    }

    public override void EnterState()
    {
        base.EnterState();

        currentVelocity = 0f;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (agent.rb2d.velocity.magnitude < 0.1f)
            agent.TransitionToState(StateType.Idle);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        CalculateSpeed();
        agent.rb2d.velocity = currentVelocity * agent.agentInput.MovementVector;
    }

    private void CalculateSpeed()
    {
        if (agent.agentInput.MovementVector.magnitude > 0)
        {
            currentVelocity += agent.statsController.GetBaseAcceleration() * Time.deltaTime;
        }
        else
        {
            currentVelocity -= agent.statsController.GetBaseDeacceleration() * Time.fixedDeltaTime;
        }
        currentVelocity = Mathf.Clamp(currentVelocity, 0f, agent.statsController.GetBaseMoveSpeed());
    }
}
