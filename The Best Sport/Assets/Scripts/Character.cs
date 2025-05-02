using UnityEngine;
using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

[Serializable]
public class Character
{
    public bool grounded { get; set; }

    public CharacterObject myCharacter;

    public Rigidbody rb { get; private set; }

    string myName;

    AbilityWithInput[] abilities;

    public PlayerInput myPlayer;

    public void Initialize(PlayerInput _playerInput, Rigidbody _rb) 
    { 
        myPlayer = _playerInput;
        rb = _rb;
        ReadOutCharacter(myCharacter);
        InitializeAbilities();
    }

    public void Disable()
    {
        foreach (AbilityWithInput a in abilities)
        {
            if (a.input != null)
            {
                myPlayer.actions[a.input.name].performed -= a.ability.PerformOnInput;
                myPlayer.actions[a.input.name].canceled -= a.ability.PerformOnCancelInput;
            }
            if (a.secondaryInput != null)
            {
                myPlayer.actions[a.secondaryInput.name].performed -= a.ability.PerformOnSecondaryInput;
                myPlayer.actions[a.secondaryInput.name].canceled -= a.ability.PerformOnSecondaryCancelInput;
            }
        }
    }

    public void LogicStart()
    {

    }

    public void LogicUpdate()
    {
        foreach(AbilityWithInput a in abilities) 
        {
            a.ability.PerformOnUpdate();
        }
    }

    public void ReadOutCharacter(CharacterObject _toRead)
    {
        myName = _toRead.CharacterName;

        abilities = new AbilityWithInput[_toRead.abilities.Length];
        for(int i = 0; i < _toRead.abilities.Length; i++) 
        {
            AbilityWithInput reference = _toRead.abilities[i];
            abilities[i] = new AbilityWithInput(reference);
        }
    }

    public void DrawGizmos()
    {
        foreach(AbilityWithInput a in abilities)
        {
            a.ability.OnDrawGizmos();
        }
    }

    void InitializeAbilities()
    {
        foreach(AbilityWithInput a in abilities)
        { 
            a.ability.Initialize(this);
            if(a.input != null)
            {
                myPlayer.actions[a.input.name].performed += a.ability.PerformOnInput;
                myPlayer.actions[a.input.name].canceled += a.ability.PerformOnCancelInput;
            }
            if (a.secondaryInput != null)
            {
                myPlayer.actions[a.secondaryInput.name].performed += a.ability.PerformOnSecondaryInput;
                myPlayer.actions[a.secondaryInput.name].canceled += a.ability.PerformOnSecondaryCancelInput;
            }
        }
    }
}
