using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private GameResourceManager resourceManager => GameResourceManager.Instance;

    private Weapon currentWeapon;

    public void SetupWeapon(int weaponId)
    {
        var data = resourceManager.GetWeaponDataById(weaponId);
        currentWeapon = data.GenerateWeapon();
    }

    public void OnShoot(Vector2 pointerPos)
    {
        currentWeapon?.OnShoot(pointerPos);
    }

    public void OnStopShooting(Vector2 pointerPos)
    {
        currentWeapon?.OnStopShooting(pointerPos);
    }

}
