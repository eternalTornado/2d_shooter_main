using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseBrain : MonoBehaviour
{
    public Vector2 MovementVector { get; set; }

    public Action<Vector2> OnMovement { get; set; }

    public abstract void CallOnMovement(Vector2 movementVector);

    #region Custom state action

    //Custom MoveState
    public virtual void MoveStateOnAnimationAction() { }
    public virtual void MoveStateOnAnimationComplete() { }

    #endregion

    #region Called by agent

    public virtual void OnStart() { }
    public virtual void OnUpdate() { }

    #endregion
}
