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

    public void OnShoot()
    {
        currentWeapon?.OnShoot();
    }

    public void OnStopShooting()
    {
        currentWeapon?.OnStopShooting();
    }

}
