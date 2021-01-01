using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharInfoDisplay : MonoBehaviour
{
    public List<Class> classes;
    public TMP_Dropdown classesDropdown;

    public List<Race> races;
    public TMP_Dropdown racesDropdown;

    private void Awake()
    {
        FillDropdown(classes, classesDropdown);
        FillDropdown(races, racesDropdown);

        classesDropdown.onValueChanged.AddListener(ModifyClass);
        racesDropdown.onValueChanged.AddListener(ModifyRace);
    }

    private void ModifyRace(int raceIndex)
    {
        CharacterManager.instance.character.characterRace = races[raceIndex];
        CharacterManager.instance.ResetValues();
    }

    private void ModifyClass(int classIndex)
    {
        CharacterManager.instance.character.characterClass = classes[classIndex];
        CharacterManager.instance.ResetValues();
    }

    public void FillDropdown<T>(List<T> items, TMP_Dropdown dropdown) where T : ScriptableObject
    {
        List<TMP_Dropdown.OptionData> optionDatas = new List<TMP_Dropdown.OptionData>();
        foreach (T item in items)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = item.name;
            optionDatas.Add(data);
        }
        dropdown.AddOptions(optionDatas);
    }
}
