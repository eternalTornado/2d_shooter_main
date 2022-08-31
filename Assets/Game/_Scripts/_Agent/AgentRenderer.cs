using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentRenderer : MonoBehaviour
{
    [SerializeField] Animator animator;

    public Action OnAnimationComplete;

    public void OnMovement(Vector2 movementVector)
    {
        if (movementVector.x > 0)
            this.transform.localScale = Vector3.one;
        if (movementVector.x < 0)
            this.transform.localScale = new Vector3(-1f, 1, 1);
    }

    public void PlayAnimation(AnimType type)
    {
        animator.Play(type.ToString(), 0, 0);
    }

    public void InvokeOnAnimationComplete()
    {
        OnAnimationComplete?.Invoke();
    }
}

public enum AnimType
{
    Idle = 0,
    Move = 1
}
