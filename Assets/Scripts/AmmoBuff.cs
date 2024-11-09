using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AmmoBuff : PowerupEffect
{
    public int ammoIncrease = 20;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Ammo>().ammo.value += ammoIncrease;
    }
}
