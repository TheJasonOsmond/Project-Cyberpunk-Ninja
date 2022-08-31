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
    public float MaxHealthFlatBonus;

    public float MaxHealthPercentBonus;

    public static new string TargetInventoryName =  "BoonInventory";

    public override bool Pick(string playerID)
    { 
        if (TargetInventory(playerID).Owner == null)
        {
            Debug.Log("Max Health Boon Failed to Pick: 1");
            Debug.Log("Target Inventory: " + TargetInventory(playerID));
            return false;
        }

        HealthModdable characterHealth = TargetInventory(playerID).Owner.GetComponent<HealthModdable>();

        if (characterHealth != null)
        {
            characterHealth.UpdateMaxHealth(MaxHealthFlatBonus, MaxHealthPercentBonus);
            Debug.Log("Max Health Boon Picked");
            return true;
        }
        else
        {
            Debug.Log("Max Health Boon Failed to Pick: 2");
            return false;
        }
    }

}
