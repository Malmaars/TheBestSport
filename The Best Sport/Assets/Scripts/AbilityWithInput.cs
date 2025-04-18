using System;
using UnityEngine.InputSystem;
using UnityEngine;

[Serializable]
public class AbilityWithInput
{
    public AbilityWithInput(AbilityWithInput reference)
    {
        string type = reference.ability.GetType().Name;
        
        switch (type)
        {
            case "Jump":
                ability = new Jump(reference.ability as Jump);
                break;
            case "Walk":
                ability = new Walk(reference.ability as Walk);
                break;
            case "AirControl":
                ability = new AirControl(reference.ability as AirControl);
                break;
        }

        input = reference.input;
    }
    [SerializeReference]
    public Ability ability;
    public InputActionReference input;
}
