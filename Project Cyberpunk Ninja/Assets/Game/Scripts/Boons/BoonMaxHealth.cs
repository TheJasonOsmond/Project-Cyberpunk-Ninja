using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine;


public class BoonMaxHealth : CharacterBoon
{
    [Header("Health")]
    [MMInformation("Here you need specify the amount of health gained when picking this item.", MMInformationAttribute.InformationType.Info, false)]
    
    /// the amount of health to add to the player when the item is used
    [Tooltip("the amount of max health to add to the player when the item is picked")]
    public float maxHealthFlatBonus;

    public float maxHealthPercentBonus;

/*    protected override void GetOwnerInfo(string playerID)
    {
        _owner = TargetInventory(playerID).Owner;
    }*/

    public override void AddBoon()
    {
        HealthModdable characterHealth = _owner.GetComponent<HealthModdable>();

        if (characterHealth != null)
        {
            characterHealth.UpdateMaxHealth(maxHealthFlatBonus, maxHealthPercentBonus);
            Debug.Log("Max Health Boon Picked");
        }

    }

    public override void RemoveBoon()
    {
        throw new System.NotImplementedException();
    }
}
