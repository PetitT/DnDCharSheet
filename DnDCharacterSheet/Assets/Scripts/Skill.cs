using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Skill : ScriptableObject
{
    public Ability keyAbility;
    public int ranks;
    public int passive => GetPassive();
    public int currentScoreAlteration;
    public int abilityModifier => keyAbility.currentModifier;
    public int totalSkillModifier => GetTotalSkillModifier();

    public int GetTotalSkillModifier()
    {
        int total = ranks + abilityModifier + currentScoreAlteration + passive;
        return total;
    }

    public int GetPassive()
    {
        RacialSKillModifier raceModifier = CharacterManager.instance.character.characterRace.racialSkillModifiers.Where(t => t.skill == this).FirstOrDefault();
        if (raceModifier == null)
        {
            return 0;
        }
        else
        {
            return raceModifier.modifier;
        }
    }

    public string notes;
}
