using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprWeapon;
    private float desiredAngle;

    public void RotateWeapon(Vector2 pointerPos)
    {
        var pointerDirection = (Vector3)pointerPos - this.transform.position;
        desiredAngle = Mathf.Atan2(pointerDirection.y, pointerDirection.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);

        sprWeapon.transform.localScale = new Vector3(1f, (desiredAngle > 90 || desiredAngle < -90) ? -1 : 1, 1);
    }
}
