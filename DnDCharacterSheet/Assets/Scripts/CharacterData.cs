using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public Class characterClass;
    public Race characterRace;
    public ArmorClass armorClass = new ArmorClass();
    public AttackManager attackManager = new AttackManager();

    public List<Ability> abilities;
    public List<Skill> skills;
    public List<SavingThrow> savingThrows;
}
