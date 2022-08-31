using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    private Vector2 movementVector;
    private Action<Vector2> onMovement;

    public Vector2 MovementVector { get =>  movementVector; set { movementVector = value; } }
    public Action<Vector2> OnMovement { get => onMovement; set { onMovement = value; } }

    private void Update()
    {
        HandleOnMovement();
    }

    private void HandleOnMovement()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        CallOnMovement(MovementVector);
    }

    public void CallOnMovement(Vector2 movementVector)
    {
        MovementVector = movementVector;
        OnMovement?.Invoke(MovementVector);
    }
}
