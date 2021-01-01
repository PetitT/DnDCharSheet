using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillsDisplay : MonoBehaviour
{
    const string nameString = "SkillName";
    const string abilityBackground = "AbilityBackground";
    const string statString = "Stat";
    const string skillModifierString = "SkillIcon";
    const string abilityModifierString = "AbilityModifier";
    const string passiveString = "Passive";
    const string ranksString = "Ranks";
    const string currentAlteration = "CurrentAlteration";

    private List<SkillDisplay> displays = new List<SkillDisplay>();

    private void Start()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            SkillDisplay newDisplay = new SkillDisplay();
            newDisplay.skill = skills[i];

            newDisplay.name = skillObjects[i].transform.Find(nameString).GetComponent<TextMeshProUGUI>();
            newDisplay.keyAbility = skillObjects[i].transform.Find(abilityBackground).transform.Find(statString).GetComponent<TextMeshProUGUI>();
            newDisplay.skillModifier = skillObjects[i].transform.Find(skillModifierString).GetComponentInChildren<TextMeshProUGUI>();
            newDisplay.abilityModifier = skillObjects[i].transform.Find(abilityBackground).transform.Find(abilityModifierString).GetComponent<TextMeshProUGUI>();
            newDisplay.passive = skillObjects[i].transform.Find(passiveString).GetComponentInChildren<TextMeshProUGUI>();
            newDisplay.ranks = skillObjects[i].transform.Find(ranksString).GetComponent<TMP_InputField>();
            newDisplay.currentAlteration = skillObjects[i].transform.Find(currentAlteration).GetComponent<TMP_InputField>();

            newDisplay.ranks.onValueChanged.AddListener(newDisplay.ModifyRanks);
            newDisplay.currentAlteration.onValueChanged.AddListener(newDisplay.ModifyCurrentAlteration);

            newDisplay.ModifyRanks(newDisplay.ranks.text);
            newDisplay.ModifyCurrentAlteration(newDisplay.currentAlteration.text);
            newDisplay.DisplayValues();

            displays.Add(newDisplay);
        }

        CharacterManager.instance.onValuesReset += DisplayValues;
    }

    private void DisplayValues()
    {
        displays.ForEach(t => t.DisplayValues());
    }

    public List<Skill> skills;
    public List<GameObject> skillObjects;
}

[System.Serializable]
public class SkillDisplay
{
    public Skill skill;

    public TextMeshProUGUI name;
    public TextMeshProUGUI keyAbility;
    public TextMeshProUGUI skillModifier;
    public TextMeshProUGUI abilityModifier;
    public TextMeshProUGUI passive;
    public TMP_InputField ranks;
    public TMP_InputField currentAlteration;

    public void DisplayValues()
    {
        name.text = skill.name;
        DisplayKeyAbility();
        skillModifier.text = skill.GetTotalSkillModifier().ToString();
        abilityModifier.text = skill.keyAbility.currentModifier.ToString();
        passive.text = skill.GetPassive().ToString();
    }

    private void DisplayKeyAbility()
    {
        switch (skill.keyAbility.name)
        {
            case "Strength":
                keyAbility.text = CharacterManager.Strength;
                break;

            case "Constitution":
                keyAbility.text = CharacterManager.Constitution;
                break;

            case "Dexterity":
                keyAbility.text = CharacterManager.Dexterity;
                break;

            case "Intelligence":
                keyAbility.text = CharacterManager.Intelligence;
                break;

            case "Wisdom":
                keyAbility.text = CharacterManager.Wisdom;
                break;

            case "Charisma":
                keyAbility.text = CharacterManager.Charisma;
                break;

            default:
                break;
        }
    }

    public void ModifyRanks(string newRank)
    {
        skill.ranks = Convert.ToInt32(newRank);
        CharacterManager.instance.ResetValues();
    }

    public void ModifyCurrentAlteration(string newAlteration)
    {
        skill.currentScoreAlteration = Convert.ToInt32(newAlteration);
        CharacterManager.instance.ResetValues();
    }
}
