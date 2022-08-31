using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;

public class CharacterAllowBoons : MonoBehaviour
{
    public string playerID;

    private string _inventoryName = "BoonInventory";
    private Inventory _boonInventory;

    void Start()
    {
        //Find Boon inventory and set owner to this player
        _boonInventory = Inventory.FindInventory(_inventoryName, playerID);
    
        if (_boonInventory != null)
            _boonInventory.SetOwner(transform.gameObject);
    }
}
