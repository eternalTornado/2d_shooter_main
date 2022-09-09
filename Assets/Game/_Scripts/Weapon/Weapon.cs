using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO weaponData;

    public Weapon(WeaponDataSO weaponData)
    {
        this.weaponData = weaponData;
    }

    public abstract void OnShoot();
    public abstract void OnStopShooting();
}
