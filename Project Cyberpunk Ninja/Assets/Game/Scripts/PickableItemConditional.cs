using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.TopDownEngine
{
    public class PickableItemConditional : PickableItem
    {
		public bool isPickable = false;

		protected override bool CheckIfPickable()
		{
			// if what's colliding with the coin ain't a characterBehavior, we do nothing and exit
			_character = _collidingObject.GetComponent<Character>();
			if (_character == null)
			{
				return false;
			}
			if (_character.CharacterType != Character.CharacterTypes.Player)
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