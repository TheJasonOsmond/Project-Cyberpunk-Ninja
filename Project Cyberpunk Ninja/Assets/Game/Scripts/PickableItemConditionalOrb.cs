using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;


namespace MoreMountains.TopDownEngine
{
    public class PickableItemConditionalOrb : PickableItemConditional
    {
		GameObject _owner;
		ProjectileOrb _orbProjectile;
		public Weapon orbWeapon;


		protected override void Start()
        {
            base.Start();
			_orbProjectile = GetComponent<ProjectileOrb>();
			_owner = _orbProjectile.OrbOwner;

			//Get the weapon that shot the projectile
			orbWeapon = _owner.GetComponent <CharacterHandleSecondaryWeapon>().CurrentWeapon;
			if (orbWeapon != null)
				Debug.Log("Non-Null Orb Weapon");

		}

        protected override bool CheckIfPickable()
		{
			// if what's colliding with the coin ain't a characterBehavior, we do nothing and exit
			_character = _collidingObject.GetComponent<Character>();
			if (_character == null)
			{
				return false;
			}
			
			// Colliding character must be the player that owns the orb projectile
			if (_character.CharacterType != Character.CharacterTypes.Player && !_character.gameObject.Equals(_owner))
			{
				return false;
			}
			if (_itemPicker != null)
			{
				if (!_itemPicker.Pickable())
				{
					return false;
				}
			}

            if (!isPickable)
            {
				return false;
            }

			

			return true;
		}

        protected override void Pick(GameObject picker)
        {
            base.Pick(picker);

			Debug.Log("Check if Orb Weapon");
			if (orbWeapon.name.Equals("WeapongRangedOrb") == true)
				Debug.Log("Orb Weapon");
				orbWeapon.InitiateReloadWeapon();
			//Reload Orb Weapon when picked

		}

    }
}