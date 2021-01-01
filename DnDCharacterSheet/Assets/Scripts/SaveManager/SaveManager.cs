using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

[ExecuteInEditMode]
public class SaveManager : MonoBehaviour
{
    string filePath = "/DnDCharSave.txt";
    string path;

    [SerializeField] private List<TMP_InputField> inputFields;
    [SerializeField] private List<TMP_Dropdown> dropDowns;

    private void Awake()
    {
#if UNITY_EDITOR
        inputFields = FindObjectsOfType<TMP_InputField>().ToList();
        dropDowns = FindObjectsOfType<TMP_Dropdown>().ToList();
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        string dataPath = Application.persistentDataPath;
        path = dataPath + filePath;
        CharacterManager.instance.onValuesReset += Save;
        LoadFile();
#endif
    }


    private void LoadFile()
    {
        string save = File.ReadAllText(path);
        if (string.IsNullOrEmpty(save)) { return; }

        SaveFile file = JsonUtility.FromJson<SaveFile>(save);

        for (int i = 0; i < file.textValues.Count; i++)
        {
            inputFields[i].text = file.textValues[i];
        }

        for (int i = 0; i < file.dropDownValues.Count; i++)
        {
            dropDowns[i].value = file.dropDownValues[i];
        }
    }

    public void Save()
    {
        List<string> inputFieldsValues = new List<string>();
        List<int> dropDownFieldValues = new List<int>();

        foreach (var item in inputFields)
        {
            inputFieldsValues.Add(item.text);
        }

        foreach (var item in dropDowns)
        {
            dropDownFieldValues.Add(item.value);
        }

        SaveFile saveFile = new SaveFile(inputFieldsValues, dropDownFieldValues);
        string jsonFile = JsonUtility.ToJson(saveFile);
        File.WriteAllText(path, jsonFile);
    }
}
