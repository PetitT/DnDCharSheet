using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager 
{
    public int baseAttackBonus;
    public int currentAlteration;

    public List<Weapon> weapons = new List<Weapon>();

    public void AddWeapon()
    {
        weapons.Add(new Weapon(this));
    }
}

public class Weapon
{
    public Weapon(AttackManager manager)
    {
        this.manager = manager;
    }

    public AttackManager manager;

    public int totalHitBonus => GetTotalBonusHit();

    public Ability abilityType;
    public int abilityModifier => abilityType.currentModifier;
    public int weaponBonus;

    private int GetTotalBonusHit()
    {
        int totalhit = manager.baseAttackBonus + manager.currentAlteration + abilityModifier + weaponBonus;
        return totalhit;
    }
}
