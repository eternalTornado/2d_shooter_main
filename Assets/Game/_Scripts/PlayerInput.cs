using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : BaseBrain
{
    public UnityEvent<Vector2> OnMousePositionChanged;
    public UnityEvent OnMoveStateAnimationAction;

    private Vector2 movement;

    public override void OnUpdate()
    {
        HandleOnMovement();
        HandleOnMousePosition();
    }

    public override void CallOnMovement(Vector2 movementVector)
    {
        MovementVector = movementVector;
        OnMovement?.Invoke(MovementVector);
    }

    public override void MoveStateOnAnimationAction()
    {
        OnMoveStateAnimationAction?.Invoke();
    }

    private void HandleOnMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        CallOnMovement(movement);
    }

    private void HandleOnMousePosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        OnMousePositionChanged?.Invoke(worldMousePos);
    }
}
