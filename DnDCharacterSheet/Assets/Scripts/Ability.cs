using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Ability : ScriptableObject
{
    public int baseScore;
    public int currentScoreAlteration;
    public int total => GetTotal();


    public int passive => GetPassive();
    public int currentModifier => GetCurrentModifier();

    public int GetCurrentModifier()
    {
        int total = Mathf.FloorToInt((baseScore + currentScoreAlteration + passive) / 2) - 5;
        return total;
    }

    private int GetTotal()
    {
        return baseScore + currentScoreAlteration + passive;
    }

    public int GetPassive()
    {
        RacialAbilityModifyer selectedModifier = CharacterManager.instance.character.characterRace.racialAbilityModifyers.Where(t => t.ability == this).FirstOrDefault();
        if (selectedModifier == null)
        {
            return 0;
        }
        else
        {
            return selectedModifier.modifier;
        }

    }

    public string notes;
}
