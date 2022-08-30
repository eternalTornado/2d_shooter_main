using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStatsController : MonoBehaviour
{
    [SerializeField] AgentDataSO agentData;

    public float GetBaseMoveSpeed()
    {
        return agentData.maxSpeed;
    }

    public float GetBaseAcceleration()
    {
        return agentData.acceleration;
    }

    public float GetBaseDeacceleration()
    {
        return agentData.deacceleration;
    }
}
