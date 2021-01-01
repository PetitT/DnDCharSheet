using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavingThrowsDisplay : MonoBehaviour
{
    public List<SavingThrowDisplay> displays;

    const string totalString = "Total";
    const string abilityScoreString = "AbilityScore";
    const string defaultValue = "Default";
    const string alteration = "Alteration";

    private void Awake()
    {
        foreach (var display in displays)
        {
            display.totalSave = display.savingThrowObject.transform.Find(totalString).GetComponent<TextMeshProUGUI>();
            display.abilityModifier = display.savingThrowObject.transform.Find(abilityScoreString).GetComponent<TextMeshProUGUI>();

            display.defaultScore = display.savingThrowObject.transform.Find(defaultValue).GetComponent<TMP_InputField>();
            display.currentAlteration = display.savingThrowObject.transform.Find(alteration).GetComponent<TMP_InputField>();

            display.SetDefaultScore(display.defaultScore.text);
            display.SetCurrentAlteration(display.currentAlteration.text);

            display.defaultScore.onValueChanged.AddListener(display.SetDefaultScore);
            display.currentAlteration.onValueChanged.AddListener(display.SetCurrentAlteration);

            display.ResetDisplays();
        }

        CharacterManager.instance.onValuesReset += ResetDisplays;
    }

    private void ResetDisplays()
    {
        displays.ForEach(t => t.ResetDisplays());
    }

    private void OnValidate()
    {
        displays.ForEach(t => t.name = t.savingThrow.name);
    }
}

[System.Serializable]
public class SavingThrowDisplay
{
    [HideInInspector] public string name;

    public GameObject savingThrowObject;
    public SavingThrow savingThrow;

    [HideInInspector] public TextMeshProUGUI totalSave;
    [HideInInspector] public TextMeshProUGUI abilityModifier;
    [HideInInspector] public TMP_InputField defaultScore;
    [HideInInspector] public TMP_InputField currentAlteration;

    public void ResetDisplays()
    {
        totalSave.text = savingThrow.currentSavingThrow.ToString();
        abilityModifier.text = savingThrow.abilityModifier.ToString();
    }

    public void SetDefaultScore(string newScore)
    {
        savingThrow.baseSave = Convert.ToInt32(newScore);
        CharacterManager.instance.ResetValues();
    }

    public void SetCurrentAlteration(string newAlteration)
    {
        savingThrow.currentAlteration = Convert.ToInt32(newAlteration);
        CharacterManager.instance.ResetValues();
    }
}
