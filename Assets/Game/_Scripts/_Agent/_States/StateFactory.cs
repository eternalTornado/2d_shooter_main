using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory
{
    private BaseState idleState;
    private BaseState moveState;

    public void InitState(Agent agent)
    {
        idleState = new IdleState(agent);
        moveState = new MoveState(agent);
    }

    public BaseState GetState(StateType type)
    {
        switch (type)
        {
            case StateType.Idle: return idleState;
            case StateType.Move: return moveState;
            default:
                return null;
        }
    }
}

public enum StateType
{
    Idle = 0,
    Move = 1
}
