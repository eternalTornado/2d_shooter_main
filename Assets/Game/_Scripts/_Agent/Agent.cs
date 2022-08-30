using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public IAgentInput agentInput;
    public AgentRenderer agentRenderer;
    public AgentStatsController statsController;
    public Rigidbody2D rb2d;

    private StateFactory stateFactory;
    private BaseState currentState;

    public string debugState;

    private void Awake()
    {
        agentInput = this.GetComponentInParent<IAgentInput>();
        stateFactory = new StateFactory();
    }

    private void Start()
    {
        stateFactory.InitState(this);
        agentInput.OnMovement += agentRenderer.OnMovement;
        agentInput.OnMovement += OnMovement;

        TransitionToState(StateType.Idle);
    }

    private void Update()
    {
        currentState?.OnUpdate();
    }

    private void FixedUpdate()
    {
        currentState?.OnFixedUpdate();
    }

    public void OnMovement(Vector2 movementVector)
    {
        currentState?.OnMovement(movementVector);
    }

    public void TransitionToState(StateType type)
    {
        var newState = stateFactory.GetState(type);
        if (newState == null) return;
        if (currentState != null && currentState.type == newState.type) return;

        currentState?.ExitState();

        currentState = newState;
        currentState?.EnterState();

        debugState = currentState?.type.ToString() ?? "null";
    }
}
