using System;
using UnityEngine.InputSystem;
using UnityEngine;

[Serializable]
public class AbilityWithInput
{
    [SerializeReference]
    public Ability ability;
    public InputActionReference input;
}
