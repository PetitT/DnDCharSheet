using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArmorClass
{
    public int armorBonus;
    public int shieldBonus;
    public int currentAlteration;
    public int dexModifier => CharacterManager.instance.character.abilities.Where(t => t.name == "Dexterity").FirstOrDefault().currentModifier;
    public int sizeBonus => CharacterManager.instance.character.characterRace.isSmall ? 1 : 0;

    public int totalArmorClass => GetArmorClass();

    private int GetArmorClass()
    {
        return armorBonus + shieldBonus + currentAlteration + dexModifier + sizeBonus + 10;
    }
}
