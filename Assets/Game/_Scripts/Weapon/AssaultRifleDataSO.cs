using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AssaultRilfeData", menuName ="Weapon/AssaultRifleData")]
public class AssaultRifleDataSO : WeaponDataSO
{
    public override Weapon GenerateWeapon()
    {
        return new AssaultRifle(this);
    }
}
