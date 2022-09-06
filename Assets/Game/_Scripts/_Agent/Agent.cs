using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [HideInInspector] public BaseBrain brain;
    public AgentRenderer agentRenderer;
    public AgentStatsController statsController;
    public Rigidbody2D rb2d;

    private StateFactory stateFactory;
    private BaseState currentState;

    public string debugState;

    private void Awake()
    {
        brain = this.GetComponentInParent<BaseBrain>();
        stateFactory = new StateFactory();
    }

    private void Start()
    {
        brain?.OnStart();

        stateFactory.InitState(this);
        brain.OnMovement += agentRenderer.OnMovement;
        brain.OnMovement += OnMovement;
        agentRenderer.OnAnimationAction += OnAnimationAction;
        agentRenderer.OnAnimationComplete += OnAnimationComplete;

        TransitionToState(StateType.Idle);
    }

    private void Update()
    {
        brain?.OnUpdate();
        currentState?.OnUpdate();
    }

    private void FixedUpdate()
    {
        currentState?.OnFixedUpdate();
    }

    private void OnMovement(Vector2 movementVector)
    {
        currentState?.OnMovement(movementVector);
    }

    private void OnAnimationAction()
    {
        currentState?.HandleOnAnimationAction();
    }

    private void OnAnimationComplete()
    {
        currentState?.HandleOnAnimationComplete();
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
