using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IAgentInput
{
    Vector2 MovementVector { get; set; }

    Action<Vector2> OnMovement { get; set; }

    void CallOnMovement(Vector2 movementVector);
}
