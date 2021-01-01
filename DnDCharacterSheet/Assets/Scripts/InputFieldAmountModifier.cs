using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldAmountModifier : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void AddOne()
    {
        int currentInt = Convert.ToInt32(inputField.text);
        currentInt++;
        inputField.text = currentInt.ToString();
    }

    public void RemoveOne()
    {
        int currentInt = Convert.ToInt32(inputField.text);
        currentInt--;
        inputField.text = currentInt.ToString();
    }
}
