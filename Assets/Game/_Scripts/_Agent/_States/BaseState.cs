using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public StateType type;
    public Agent agent;

    public BaseState(Agent agent)
    {
        this.agent = agent;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void OnMovement(Vector2 movementVector)
    {
        if (movementVector.magnitude > 0)
            agent.TransitionToState(StateType.Move);
    }

    public virtual void HandleOnAnimationComplete() { }
    public virtual void HandleOnAnimationAction() { }

    #region Called by Agent

    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }

    #endregion
}
