using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine;


public class BoonMaxHealth : InventoryItem
{
    [Header("Health")]
    [MMInformation("Here you need specify the amount of health gained when picking this item.", MMInformationAttribute.InformationType.Info, false)]
    
    /// the amount of health to add to the player when the item is used
    [Tooltip("the amount of max health to add to the player when the item is picked")]
    public float MaxHealthBonus;

    public override bool Pick(string playerID)
    {
        base.Pick(playerID);

        if (TargetInventory(playerID).Owner == null)
        {
            return false;
        }

        Health characterHealth = TargetInventory(playerID).Owner.GetComponent<Health>();

        if (characterHealth != null)
        {
            characterHealth.ReceiveHealth(MaxHealthBonus, TargetInventory(playerID).gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

}
