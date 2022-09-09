using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDataSO : ScriptableObject
{
    public int WeaponId;
    public Sprite SprWeapon;

    public int MaxCapacity;
    public int ReloadCapacity;
    public float DelayTime;
    public bool IsAutomatic;
    public float SpreadAngle;
    public int bulletCount; // bullet count per ammo

    public abstract Weapon GenerateWeapon();
}
