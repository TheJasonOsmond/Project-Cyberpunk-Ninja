using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;

public class ProjectileOrb : Projectile
{
    //public Fields
    [Header("Orb Projectile")]
    //Stops the movement of the projectile after a x seconds;
    public float stopAfterDuration = 0f;
    public float returnAfterDuration = 0f;



    //Protected Fields
    protected Transform Target;
    protected MagnitizeToPlayer _magToOwner;
    protected PickableItemConditionalOrb _pickableItem;
    protected ItemPickerConditional _itemPicker;

    protected WaitForSeconds _stopAfterDurationWFS;
    protected WaitForSeconds _returnAfterDurationWFS;
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        _magToOwner = GetComponent<MagnitizeToPlayer>();
        _pickableItem = GetComponent<PickableItemConditionalOrb>();
        _itemPicker = GetComponent<ItemPickerConditional>();

        _pickableItem.enabled = false;
            
    }


    protected override void Initialization()
    {
        base.Initialization();
        _stopAfterDurationWFS = new WaitForSeconds(stopAfterDuration);
        _returnAfterDurationWFS = new WaitForSeconds(returnAfterDuration);

        _pickableItem.isPickable = false;

        StartCoroutine(StopAfter());

        //Sets Item Picker Ammo to 1
        _itemPicker.ResetQuantity();
        _itemPicker.itemPickable = false;

        if (_pickableItem.orbWeapon == null)
            _pickableItem.orbWeapon = _owner.GetComponent<CharacterHandleSecondaryWeapon>().CurrentWeapon;


    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }



    //After a time, disables collider and movement
    private IEnumerator StopAfter() 
    {
        yield return _stopAfterDurationWFS;
        this.StopAt();
        StartCoroutine(ReturnAfter());
    }

    private IEnumerator ReturnAfter()
    {
        yield return _returnAfterDurationWFS;

        ReturnToOwner();
    }

    //Returns projectile to owner
    public void ReturnToOwner()
    {
        //Enable Movement
        EnableCollider();

        if (_pickableItem)
        {
            _pickableItem.isPickable = true;
        }

        if (_itemPicker)
        {
            Debug.Log("Item Pickable");
            _itemPicker.itemPickable = true;
        }

        //_pickableItem = gameObject.AddComponent<PickableItem>();

        _magToOwner.Target = _owner.transform;
        _magToOwner.StartFollowing();

        //_magnetic.enabled = true;

        ////Calculate Direction
        //Vector3 moveDirection = _owner.transform.position - transform.position;
        //moveDirection.Normalize();

        ////Calculate Rotation
        //Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);

        //SetDirection(moveDirection, targetRotation);

    }

    //Enables collider and movement
    public virtual void EnableCollider()
    {
        if (_collider != null)
        {
            _collider.enabled = true;
        }
        if (_collider2D != null)
        {
            _collider2D.enabled = true;
        }
    }

    public GameObject OrbOwner
    {
        get
        {
            return _owner;
        }
    }

}
