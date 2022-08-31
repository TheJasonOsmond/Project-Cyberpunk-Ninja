using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;


public class HealthModdable : Health
{
    [MMInspectorGroup("Health", true, 5)]

    [MMReadOnly]
    [Tooltip("a flat modifier for changing max health")]
    public float maxHealthFlatMod = 0f;

    [MMReadOnly]
    [Tooltip("a percent modifier for changing max health, calculated after the flat modifier")]
    public float maxHealthPercentMod = 1.0f;



    //MaxHealth cannot be reduced below this amount
    private float _minMaxhealth = 1f;

    public void UpdateMaxHealth(float flatModValue, float percentModValue)
    {
        maxHealthPercentMod += percentModValue;
        maxHealthFlatMod += flatModValue;

        float oldMaxHealth = MaximumHealth;

        float newMaxHealth = (InitialHealth + maxHealthFlatMod) * maxHealthPercentMod;

        if (newMaxHealth < _minMaxhealth)
        {
            newMaxHealth = _minMaxhealth;
        }

        MaximumHealth = newMaxHealth;

        // If new max health is greater or equal, increase health
        if (newMaxHealth >= oldMaxHealth)
        {
            SetHealth(CurrentHealth += (newMaxHealth - oldMaxHealth));
        }

        // Assertion: New max health < Old max health

        else if (CurrentHealth > newMaxHealth)
        {
            SetHealth(newMaxHealth);
        }

        //Else Current Health <= newMaxHealth
        else
        {
            SetHealth(CurrentHealth);
        }



    }


}




