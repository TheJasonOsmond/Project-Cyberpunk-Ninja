using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;


public abstract class CharacterBoon : InventoryItem
{
    protected GameObject _owner;
    protected Weapon _weaponPrimary;
    protected Weapon _weaponSecondary;
    protected Inventory _boonInventory;
    protected Character _character;

    protected string _weaponPrimaryType;
    protected string _weaponSecondaryType;

    public static new string TargetInventoryName = "BoonInventory";

    public override bool Pick(string playerID)
    {
        if (TargetInventory(playerID).Owner == null)
        {
            Debug.Log("Boon Failed to Pick");
            Debug.Log("Target Inventory: " + TargetInventory(playerID));
            return false;
        }
        //_owner = TargetInventory(playerID).Owner;

        GetOwnerInfo(playerID);
        AddBoon();

        return true;
    }



    public abstract void AddBoon();

    public abstract void RemoveBoon();

    protected virtual void GetOwnerInfo(string playerID)
    {
        _boonInventory = TargetInventory(playerID);
        _owner = TargetInventory(playerID).Owner;
        _character = _owner.GetComponent<Character>();

        _weaponPrimary = _owner.GetComponent<CharacterHandleWeapon>().CurrentWeapon;
        _weaponPrimaryType = getWeaponType(_weaponPrimary);
        _weaponSecondary = _owner.GetComponent<CharacterHandleSecondaryWeapon>().CurrentWeapon;
        _weaponSecondaryType = getWeaponType(_weaponSecondary);

    }

    protected string getWeaponType(Weapon weapon)
    {
        if (weapon is MeleeWeapon)
            return "Melee";
        else if (weapon is ProjectileWeapon)
            return "Projectile";
        else if (weapon is HitscanWeapon)
            return "Hitscan";
        
        return null;
    }



}
