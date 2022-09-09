using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : BaseBrain
{
    public UnityEvent<Vector2> OnMousePositionChanged;
    public UnityEvent OnMoveStateAnimationAction;

    public UnityEvent<Vector2> OnFireButtonPressed;
    public UnityEvent<Vector2> OnFireButtonReleased;

    private Vector2 movement;
    private Vector2 pointerPos;

    public override void OnUpdate()
    {
        HandleOnMovement();
        HandleOnMousePosition();
        HandleOnFire();
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

    private void HandleOnFire()
    {
        if (Input.GetMouseButtonDown(0))
            OnFireButtonPressed?.Invoke(pointerPos);

        if (Input.GetMouseButtonUp(0))
            OnFireButtonReleased?.Invoke(pointerPos);
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
        pointerPos = Camera.main.ScreenToWorldPoint(mousePos);
        OnMousePositionChanged?.Invoke(pointerPos);
    }
}
