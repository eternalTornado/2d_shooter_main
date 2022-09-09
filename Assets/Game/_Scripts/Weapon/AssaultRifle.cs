using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    public AssaultRifle(WeaponDataSO weaponData) : base(weaponData)
    {
    }

    public override void OnShoot(Vector2 pointerPos)
    {
        throw new System.NotImplementedException();
    }

    public override void OnStopShooting(Vector2 pointerPos)
    {
        throw new System.NotImplementedException();
    }
}
