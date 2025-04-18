using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Punch : Ability
{
    public float punchPower;

    public Punch(Ability reference) : base(reference) { }

    //hit anything hittable in the direction you're aiming

    public override void PerformOnInput(InputAction.CallbackContext context)
    {
        //get input direction
    }
}
