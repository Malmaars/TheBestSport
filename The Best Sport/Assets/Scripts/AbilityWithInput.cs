using System;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Reflection;

[Serializable]
public class AbilityWithInput
{
    public AbilityWithInput(AbilityWithInput reference)
    {
        Type abilityType = reference.ability.GetType();
        ConstructorInfo constructor = abilityType.GetConstructor(new[] { abilityType });

        if (constructor != null)
        {
            ability = constructor.Invoke(new object[] { reference.ability }) as Ability;
        }
        else
        {
            throw new InvalidOperationException($"No copy constructor found for type {abilityType.Name}");
        }

        input = reference.input;
    }
    [SerializeReference]
    public Ability ability;
    public InputActionReference input;
    public InputActionReference secondaryInput;
}
