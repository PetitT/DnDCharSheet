using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public static string Strength = "STR";
    public static string Constitution = "CON";
    public static string Dexterity = "DEX";
    public static string Intelligence = "INT";
    public static string Wisdom = "WIS";
    public static string Charisma = "CHA";

    private static CharacterManager _instance;
    public static CharacterManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CharacterManager>();
            }
            return _instance;

        }
        private set
        {
            _instance = value;
        }
    }

    public event Action onValuesReset;

    public CharacterData character;

    public void ResetValues()
    {
        onValuesReset?.Invoke();
    }
}
