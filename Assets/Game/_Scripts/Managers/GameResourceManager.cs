using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourceManager : MonoSingleton<GameResourceManager>
{
    private Dictionary<int, WeaponDataSO> dictWeaponData;

    private void Start()
    {
        PopulateWeaponData();
    }

    private void PopulateWeaponData()
    {
        if (dictWeaponData == null)
            dictWeaponData = new Dictionary<int, WeaponDataSO>();

        foreach(var data in Resources.LoadAll<WeaponDataSO>("WeaponDataSo"))
        {
            dictWeaponData[data.WeaponId] = data;
        }
    }

    public WeaponDataSO GetWeaponDataById(int weaponId)
    {
        if (!dictWeaponData.ContainsKey(weaponId))
            return null;

        return dictWeaponData[weaponId];
    }
}
