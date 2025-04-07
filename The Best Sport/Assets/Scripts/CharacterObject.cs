
using System;
using UnityEngine.InputSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterObject : ScriptableObject
{
    public string CharacterName;

    //some reference to visuals

    public AbilityWithInput[] abilities;
}