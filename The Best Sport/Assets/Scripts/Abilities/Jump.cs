using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Jump : Ability
{ 
    public float jumpForce;
    bool desiredJump;

    public Jump(Ability reference) : base(reference) { }

    public override void PerformOnUpdate()
    {
        HandleJump();
    }

    void HandleJump()
    {
        if (desiredJump)
        {
            desiredJump = false;
            DoJump();
        }
    }

    void DoJump()
    {
        if (!myCharacter.grounded)
            return;

        myCharacter.rb.AddForce(Vector2.up * jumpForce);
    }


    public override void PerformOnInput(InputAction.CallbackContext context)
    {
        desiredJump = true;
    }

}
