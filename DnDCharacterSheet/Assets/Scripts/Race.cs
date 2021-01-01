using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Race : ScriptableObject
{
    public List<RacialAbilityModifyer> racialAbilityModifyers;
    public List<RacialSKillModifier> racialSkillModifiers;
    public bool isSmall = false;
}

[System.Serializable]
public class RacialAbilityModifyer
{
    public Ability ability;
    public int modifier;
}

[System.Serializable]
public class RacialSKillModifier
{
    public Skill skill;
    public int modifier;
}