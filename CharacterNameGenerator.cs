using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data object that can generate a number of dancer names
/// 
/// TODO:
///     Needs to generate the number of requested <b>unique</b> character names for the dancers in our battle
/// </summary>
[CreateAssetMenu(menuName = "Battle Objects/Character Name Generator")]
[System.Serializable]
public class CharacterNameGenerator : ScriptableObject
{
    [Header("Possible first names")]
    [SerializeField]
    public List<string> firstNames;
    [Header("Possible last names")]
    [SerializeField]
    public List<string> lastNames;
    [Header("Possible nicknames")]
    [SerializeField]
    public List<string> nicknames;
    [Header("Possible adjectives to describe the character")]
    [SerializeField]
    public List<string> descriptors;
   
    public CharacterName[] GenerateNames(int namesNeeded)
    {
        //namesNeeded = 6;
        CharacterName[] names = new CharacterName[namesNeeded];
      
        //TODO - filling this with empty names so the rest of our code is safe to run without need for many null checks
       
        CharacterName emptyName = new CharacterName(string.Empty, string.Empty, string.Empty, string.Empty);
        for (int i = 0; i < names.Length; i++)
        {
            int RandomNameIndex = Random.Range(0, firstNames.Count);
            int RandomlastNameIndex = Random.Range(0, lastNames.Count);
            int RandomnickNameIndex= Random.Range(0, nicknames.Count);
            int RandomdescriptorNameIndex = Random.Range(0, descriptors.Count);
            //CharacterName[Generator].firstNames();

            names[i] = new CharacterName(firstNames[RandomNameIndex],lastNames[RandomlastNameIndex],nicknames[RandomnickNameIndex],descriptors[RandomdescriptorNameIndex]);
        }

        Debug.LogWarning("CharacterNameGenerator called, it needs to fill out the names array with unique randomly constructed character names");

        return names;
    }
}