using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;


public abstract class CharacterBoon : MonoBehaviour
{
    protected GameObject _owner;
    protected Weapon _weaponPrimary;
    protected Weapon _weaponSecondary;
    protected Inventory _boonInventory;
    protected Character _character;

    private void Awake()
    {
        _owner = _boonInventory.Owner;

        if (_owner != null)
        {
            _weaponPrimary = _owner.gameObject.MMGetComponentNoAlloc<CharacterHandleWeapon>().CurrentWeapon;
            _weaponSecondary = _owner.gameObject.MMGetComponentNoAlloc<CharacterHandleSecondaryWeapon>().CurrentWeapon;
            _character = _owner.gameObject.MMGetComponentNoAlloc<Character>();
        }


    }

    public abstract void AddBoon();

    public abstract void RemoveBoon();


}
