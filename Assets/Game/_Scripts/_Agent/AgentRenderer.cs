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
        
    }

    public void OnMousePositionChanged(Vector2 mousePos)
    {
        var direction = (Vector3)mousePos - this.transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        if (result.z > 0)
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (result.z < 0)
            this.transform.localScale = Vector3.one;
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
