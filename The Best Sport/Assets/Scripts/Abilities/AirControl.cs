using UnityEngine;
using UnityEngine.InputSystem;

public class AirControl : Ability
{
    public AirControl(AirControl reference)
    {
        maxSpeed = reference.maxSpeed;
        moveSpeed = reference.moveSpeed;
    }
    public float maxSpeed;
    public float moveSpeed;
    Vector2 moveInput;

    public override void PerformOnUpdate()
    {
        if (myCharacter.grounded)
            return;

        if (myCharacter.rb.linearVelocity.x > maxSpeed && moveInput.x > 0 || myCharacter.rb.linearVelocity.x < -maxSpeed && moveInput.x < 0)
            return;

        myCharacter.rb.linearVelocity += (new Vector2((moveInput.normalized).x * moveSpeed, 0));
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
