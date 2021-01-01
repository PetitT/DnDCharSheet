using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SavingThrow : ScriptableObject
{
    public Ability keyAbility;
    public int abilityModifier => keyAbility.currentModifier;
    public int baseSave;
    public int currentAlteration;
    public int currentSavingThrow => baseSave + abilityModifier + currentAlteration;

    public string notes;
}
