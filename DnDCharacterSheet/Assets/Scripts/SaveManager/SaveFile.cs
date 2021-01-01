using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFile
{
    public List<string> textValues;
    public List<int> dropDownValues;

    public SaveFile(List<string> textValues, List<int> dropDownValues)
    {
        this.textValues = textValues;
        this.dropDownValues = dropDownValues;
    }
}
