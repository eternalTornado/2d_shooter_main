using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprRenderer;

    private GameResourceManager resourceManager => GameResourceManager.Instance;
    private WeaponDataSO data;

    public void SetupWeapon(int weaponId)
    {
        data = resourceManager.GetWeaponDataById(weaponId);
        if (data == null)
            return;

        sprRenderer.sprite = data.SprWeapon;
    }
}
