using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.TopDownEngine
{
    public class PickableItemConditionalOrb : PickableItemConditional
    {
		GameObject _owner;
		ProjectileOrb _orbProjectile;

        protected override void Start()
        {
            base.Start();
			_orbProjectile = GetComponent<ProjectileOrb>();
			_owner = _orbProjectile.OrbOwner; 
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

		//Returns the character
		public Character collidingCharacter
        {
            get
            {
				return _character;
            }
        }




	}
}