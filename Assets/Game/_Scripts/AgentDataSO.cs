using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/AgentData")]
public class AgentDataSO : ScriptableObject
{
    public float maxSpeed = 5f;
    public float acceleration = 50f;
    public float deacceleration = 50f;
}
