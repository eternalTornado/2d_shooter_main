using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
    public void OnMovement(Vector2 movementVector)
    {
        if (movementVector.x > 0)
            this.transform.localScale = Vector3.one;
        if (movementVector.x < 0)
            this.transform.localScale = new Vector3(-1f, 1, 1);
    }
}
