using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Ability
{
    protected Character myCharacter;

    public virtual void Initialize(Character _character)
    {
        myCharacter = _character;
    }


    public virtual void PerformOnUpdate()
    {
        return;
    }

    public virtual void PerformOnInput(InputAction.CallbackContext context)
    {
        return;
    }


    public virtual void PerformOnCancelInput(InputAction.CallbackContext context)
    {
        return;
    }
}
