using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WeaponsDisplay : MonoBehaviour
{
    const string totalhit = "TotalHitBonus";
    const string abilityType = "AbilityType";
    const string abilityModifier = "AbilityModifier";
    const string weaponBonus = "WeaponBonus";

    public TMP_InputField baseAttackBonusField;
    public TMP_InputField currentAttackAlterationField;

    public List<GameObject> weaponsDisplayObjects;
    public List<WeaponDisplay> weaponDisplays = new List<WeaponDisplay>();

    private void Start()
    {
        int index = 0;
        foreach (var display in weaponsDisplayObjects)
        {
            CharacterManager.instance.character.attackManager.AddWeapon();
            WeaponDisplay newDisplay = new WeaponDisplay();
            newDisplay.index = index;
            index++;

            newDisplay.totalHitBonusField = display.transform.Find(totalhit).GetComponent<TextMeshProUGUI>();
            newDisplay.abilityModifierField = display.transform.Find(abilityModifier).GetComponent<TextMeshProUGUI>();

            newDisplay.abilityType = display.transform.Find(abilityType).GetComponent<TMP_Dropdown>();
            newDisplay.weaponBonus = display.transform.Find(weaponBonus).GetComponent<TMP_InputField>();

            newDisplay.weaponBonus.onValueChanged.AddListener(newDisplay.ModifyWeaponBonus);
            newDisplay.abilityType.onValueChanged.AddListener(newDisplay.ModifyAbilityType);

            newDisplay.ModifyWeaponBonus(newDisplay.weaponBonus.text);
            newDisplay.ModifyAbilityType(newDisplay.abilityType.value);

            weaponDisplays.Add(newDisplay);

        }

        CharacterManager.instance.onValuesReset += DisplayValues;
        baseAttackBonusField.onValueChanged.AddListener(ModifyBaB);
        currentAttackAlterationField.onValueChanged.AddListener(ModifyAlteration);
        DisplayValues();
    }

    private void ModifyAlteration(string alteration)
    {
        CharacterManager.instance.character.attackManager.currentAlteration = Convert.ToInt32(alteration);
        CharacterManager.instance.ResetValues();
    }

    private void ModifyBaB(string BaB)
    {
        CharacterManager.instance.character.attackManager.baseAttackBonus = Convert.ToInt32(BaB);
        CharacterManager.instance.ResetValues();
    }

    private void DisplayValues()
    {
        weaponDisplays.ForEach(t => t.ResetDisplay());
    }
}

public class WeaponDisplay
{
    public TextMeshProUGUI totalHitBonusField;
    public TextMeshProUGUI abilityModifierField;
    public TMP_Dropdown abilityType;
    public TMP_InputField weaponBonus;

    public int index;

    internal void ModifyAbilityType(int abilityTypeIndex)
    {
        string abilityString = abilityTypeIndex == 0 ? "Strength" : "Dexterity";
        Ability ability = CharacterManager.instance.character.abilities.Where(t => t.name == abilityString).FirstOrDefault();
        CharacterManager.instance.character.attackManager.weapons[index].abilityType = ability;
        CharacterManager.instance.ResetValues();
    }

    internal void ModifyWeaponBonus(string weaponBonus)
    {
        CharacterManager.instance.character.attackManager.weapons[index].weaponBonus = Convert.ToInt32(weaponBonus);
        CharacterManager.instance.ResetValues();
    }

    internal void ResetDisplay()
    {
        totalHitBonusField.text = CharacterManager.instance.character.attackManager.weapons[index].totalHitBonus.ToString();
        abilityModifierField.text = CharacterManager.instance.character.attackManager.weapons[index].abilityModifier.ToString();
    }
}
