using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmorClassDisplay : MonoBehaviour
{
    public GameObject displayObject;
    private ArmorClass armorClass;

    const string total = "TotalValue";
    const string dexModifier = "DexModifier";
    const string sizeModifier = "SizeModifier";
    const string armor = "Armor";
    const string shield = "Shield";
    const string currentAlteration = "Alteration";

    private TextMeshProUGUI totalValue;
    private TextMeshProUGUI dexModifierValue;
    private TextMeshProUGUI sizeModifierValue;

    private TMP_InputField armorValue;
    private TMP_InputField shieldValue;
    private TMP_InputField alterationValue;

    private void Awake()
    {
        armorClass = CharacterManager.instance.character.armorClass;

        totalValue = displayObject.transform.Find(total).GetComponent<TextMeshProUGUI>();
        dexModifierValue = displayObject.transform.Find(dexModifier).GetComponent<TextMeshProUGUI>();
        sizeModifierValue = displayObject.transform.Find(sizeModifier).GetComponent<TextMeshProUGUI>();

        armorValue = displayObject.transform.Find(armor).GetComponent<TMP_InputField>();
        shieldValue = displayObject.transform.Find(shield).GetComponent<TMP_InputField>();
        alterationValue = displayObject.transform.Find(currentAlteration).GetComponent<TMP_InputField>();

        armorValue.onValueChanged.AddListener(ModifyArmor);
        shieldValue.onValueChanged.AddListener(ModifyShield);
        alterationValue.onValueChanged.AddListener(ModifyAlteration);

        ResetDisplays();

        CharacterManager.instance.onValuesReset += ResetDisplays;
    }

    private void ModifyAlteration(string alteration)
    {
        armorClass.currentAlteration = Convert.ToInt32(alteration);
        CharacterManager.instance.ResetValues();
    }

    private void ModifyShield(string shield)
    {
        armorClass.shieldBonus = Convert.ToInt32(shield);
        CharacterManager.instance.ResetValues();
    }

    private void ModifyArmor(string armor)
    {
        armorClass.armorBonus = Convert.ToInt32(armor);
        CharacterManager.instance.ResetValues();
    }

    private void ResetDisplays()
    {
        totalValue.text = armorClass.totalArmorClass.ToString();
        dexModifierValue.text = armorClass.dexModifier.ToString();
        sizeModifierValue.text = armorClass.sizeBonus.ToString();
    }
}
