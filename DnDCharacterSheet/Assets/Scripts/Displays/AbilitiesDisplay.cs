using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesDisplay : MonoBehaviour
{
    public List<AbilityDisplay> displays;

    const string defaultValueString = "Base";
    const string alterationValueString = "Alteration";
    const string passiveString = "Passive";
    const string modifierString = "Modifier";
    const string totalString = "Total";

    private void Awake()
    {
        foreach (var display in displays)
        {
            display.defaultValues = display.displayObject.transform.Find(defaultValueString).GetComponent<TMP_InputField>();
            display.currentAlteration = display.displayObject.transform.Find(alterationValueString).GetComponent<TMP_InputField>();

            display.modifyDefaultValue(display.defaultValues.text);
            display.modifyAlterationValue(display.currentAlteration.text);

            display.passive = display.displayObject.transform.Find(passiveString).GetComponent<TextMeshProUGUI>();
            display.currentAbilityModifier = display.displayObject.transform.Find(modifierString).GetComponent<TextMeshProUGUI>();
            display.total = display.displayObject.transform.Find(totalString).GetComponent<TextMeshProUGUI>();

            display.DisplayValues();

            display.defaultValues.onValueChanged.AddListener(display.modifyDefaultValue);
            display.currentAlteration.onValueChanged.AddListener(display.modifyAlterationValue);
        }

        CharacterManager.instance.onValuesReset += DisplayValues;
    }

    private void DisplayValues()
    {
        displays.ForEach(t => t.DisplayValues());
    }

    private void OnValidate()
    {
        displays.ForEach(t => t.name = t.ability.name);
    }
}

[System.Serializable]
public class AbilityDisplay
{
    [HideInInspector] public string name;
    public Ability ability;
    public GameObject displayObject;

    [HideInInspector] public TMP_InputField defaultValues;
    [HideInInspector] public TMP_InputField currentAlteration;

    [HideInInspector] public TextMeshProUGUI passive;
    [HideInInspector] public TextMeshProUGUI currentAbilityModifier;
    [HideInInspector] public TextMeshProUGUI total;

    public void DisplayValues()
    {
        passive.text = ability.GetPassive().ToString();
        currentAbilityModifier.text = ability.GetCurrentModifier().ToString();
        total.text = ability.total.ToString();
    }

    public void modifyDefaultValue(string defaultValue)
    {
        ability.baseScore = Convert.ToInt32(defaultValue);
        CharacterManager.instance.ResetValues();
    }

    public void modifyAlterationValue(string alterationValue)
    {
        ability.currentScoreAlteration = Convert.ToInt32(alterationValue);
        CharacterManager.instance.ResetValues();
    }
}
