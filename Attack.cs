using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    public readonly float damage;
    public readonly bool isCritical;

    public Attack(float damage, bool isCritical)
    {
        this.damage = damage;
        this.isCritical = isCritical;
    }

    public float GetDamage() { return damage; }
    public bool GetCritical() { return isCritical; }
}
