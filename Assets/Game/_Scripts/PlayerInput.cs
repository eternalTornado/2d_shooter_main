using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    public Vector2 MovementVector { get; set; }
    public Action<Vector2> OnMovement { get; set; }

    public UnityEvent<Vector2> OnMousePositionChanged;

    private Vector2 movement;

    private void Update()
    {
        HandleOnMovement();
        HandleOnMousePosition();
    }

    private void HandleOnMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        CallOnMovement(movement);
    }

    private void HandleOnMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        OnMousePositionChanged?.Invoke(mousePos);
    }

    public void CallOnMovement(Vector2 movementVector)
    {
        MovementVector = movementVector;
        OnMovement?.Invoke(MovementVector);
    }
}
