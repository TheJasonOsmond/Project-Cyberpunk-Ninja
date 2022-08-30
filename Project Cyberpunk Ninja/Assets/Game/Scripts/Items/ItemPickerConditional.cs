using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;


public class ItemPickerConditional : ItemPicker
{
	//if item can be picked
	[Tooltip("if item can be picked")]
	public bool itemPickable = false;

	public override bool Pickable()
	{
		if (!itemPickable)
			return false;

		return base.Pickable();
	}



}
