using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Walk : Ability
{

    public Walk(Walk reference)
    {
        maxSpeed = reference.maxSpeed;
        moveSpeed = reference.moveSpeed;
    }
    public float maxSpeed;
    public float moveSpeed;
    Vector2 moveInput;

    public override void PerformOnUpdate()
    {
        if (!myCharacter.grounded)
            return;

        myCharacter.rb.linearVelocity = Vector2.MoveTowards(myCharacter.rb.linearVelocity, new Vector2((moveInput.normalized).x * maxSpeed, myCharacter.rb.linearVelocity.y), moveSpeed);
    }

    public override void PerformOnInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.y = 0;
    }

    public override void PerformOnCancelInput(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }
}
