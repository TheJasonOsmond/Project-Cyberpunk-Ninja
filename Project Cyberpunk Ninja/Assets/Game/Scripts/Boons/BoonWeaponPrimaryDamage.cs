using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonWeaponPrimaryDamage : CharacterBoon
{
    [Header("Damage")]
    [MMInformation("Specify the amount of damage gained when picking this item.", MMInformationAttribute.InformationType.Info, false)]

    public float damagePercentBonus;
    public float damageFlatBonus;

    protected Weapon weapon;

    protected override void GetOwnerInfo(string playerID)
    {
        base.GetOwnerInfo(playerID);
    }


    public override void AddBoon() { 
        weapon = _weaponPrimary;

        if(_weaponPrimaryType == null)
            return;

        if (_weaponPrimaryType.Equals("Melee"))
        {
            Debug.Log("Adding BoonWeaponDamage to Weapon type:" + _weaponPrimaryType);
            ModifyDamageMeleeWeapon();
        }



    }

    public override void RemoveBoon()
    {
        Debug.Log("Removed ");

    }

    protected void ModifyDamageMeleeWeapon()
    {
        MeleeWeapon meleeWeapon = (MeleeWeapon) weapon;


        Debug.Log(meleeWeapon.GetInstanceID());
        Debug.Log(_weaponPrimary.GetInstanceID());
        meleeWeapon.MinDamageCaused = (int) ((meleeWeapon.MinDamageCaused * (1 + damagePercentBonus)) + damageFlatBonus);
        meleeWeapon.MinDamageCaused = 100;
        meleeWeapon.MaxDamageCaused = (int) ((meleeWeapon.MaxDamageCaused * (1 + damagePercentBonus)) + damageFlatBonus);

    }
}
