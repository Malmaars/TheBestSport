using NaughtyAttributes.Test;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Ability
{
    protected Character myCharacter;
    
    public Ability() { }

    public Ability(Ability reference)
    {
        // Use reflection to copy all public instance fields
        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var field in fields)
        {
            field.SetValue(this, field.GetValue(reference));
        }
    }

    public virtual void Initialize(Character _character)
    {
        myCharacter = _character;
    }

    public virtual void PerformOnUpdate() { return; }

    public virtual void PerformOnInput(InputAction.CallbackContext context) { return; }

    public virtual void OnDrawGizmos() { return; }

    public virtual void PerformOnSecondaryInput(InputAction.CallbackContext context) { return; }

    public virtual void PerformOnCancelInput(InputAction.CallbackContext context) { return; }
    public virtual void PerformOnSecondaryCancelInput(InputAction.CallbackContext context) { return; }
}
