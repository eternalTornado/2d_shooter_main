using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    private float desiredAngle;

    [SerializeField] private WeaponRenderer weaponRenderer;
    [SerializeField] private WeaponBehaviour weaponBehaviour;

    public void SetupWeapon(int weaponId)
    {
        weaponRenderer.SetupWeapon(weaponId);
        weaponBehaviour.SetupWeapon(weaponId);
    }

    //Called by events from brain
    public void RotateWeapon(Vector2 pointerPos)
    {
        var pointerDirection = (Vector3)pointerPos - this.transform.position;
        desiredAngle = Mathf.Atan2(pointerDirection.y, pointerDirection.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);

        weaponRenderer.transform.localScale = new Vector3(1f, (desiredAngle > 90 || desiredAngle < -90) ? -1 : 1, 1);
    }

    public void Shoot()
    {
        //weaponRenderer
    }
}
